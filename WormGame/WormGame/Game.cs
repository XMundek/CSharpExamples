using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace WormGame
{
    public enum GameStatus
    {
        Waiting, Running, Win, Kill, GameOver, TimeExpired
    }
    public delegate void EndGameEvent(Game sender, GameStatus status);

    public class Game : VisualObject
    {
        public string LoginName { get; set; }
        public event EndGameEvent EndGame;
        private object _lock = new object();
        protected int _speed;
        public int Speed
        {
            get => _speed;
            set => SetProperty(ref _speed, value, nameof(Speed));
        }
        private int _timeLeft;
        public int TimeLeft
        {
            get => _timeLeft;
            set => SetProperty(ref _timeLeft, value, nameof(TimeLeft));
        }
        private int _lifes;
        public int Lifes
        {
            get => _lifes;
            set => SetProperty(ref _lifes, value, nameof(Lifes));
        }
        private int _points;
        public int Points
        {
            get => _points;
            set => SetProperty(ref _points, value, nameof(Points));
        }
        public GameStatus Status { get; set; }
        private static readonly Dictionary<GameStatus, string> Messages = new Dictionary<GameStatus, string>()
        {
            {GameStatus.Running, "Game in progress" },
            {GameStatus.Waiting, "Game is stopped" },
            {GameStatus.Win, "Hurraaa!!!" },
            {GameStatus.Kill, "Buuuuu!!!" },
            {GameStatus.GameOver, "Game over" },
            {GameStatus.TimeExpired, "Time expired !!!" },
        };
        public string StatusMessage => Messages[Status];
        private Timer _timer;
        public bool IsRunning => _timer != null;
        public bool IsWaiting => _timer == null;
        public string CommandName => IsRunning ? "Stop" : "Start";
        public bool IsCommandEnabled => _lifes > 0 && _timeLeft > 0;
        public Player Player { get; private set; }
        private ObservableCollection<Worm> _worms;

        public ObservableCollection<Worm> Worms => _worms;
        public Game()
        {
            _speed = 4;
            _points = 0;
            _lifes = 4;
            _timeLeft = 60;
        }
        public bool Init()
        {
            if (Player != null) return false;
            Player = new Player(this);
            _worms = new ObservableCollection<Worm>();
            const int boxHeight = 40;
            const int boxHeightWithMargin = boxHeight + 5;
            for (int i = 0; i<_height - 2* boxHeightWithMargin; i += boxHeightWithMargin)
            {
                _worms.Add(new Worm(this, i, boxHeight));
            }
            ResetGame();
            return true;
        }
        public void WinPlayer()
        {
            Stop();
            Points++;
            RaiseEndGame(GameStatus.Win);
            Player.SetStartPosition();
            Start();
        }
        public void KillPlayer()
        {
            Stop();
            Lifes--;
            if (Lifes == 0)
                RaiseEndGame(GameStatus.GameOver);
            else
            {
                RaiseEndGame(GameStatus.Kill);
                Player.SetStartPosition();
                Start();            
            }
        }   
        public void ResetGame()
        {
            Lifes = 5;
            Points = 0;
            TimeLeft = 60;
            var rnd = new Random();
            foreach(var worm in _worms)
            {
                worm.X = 0;
                worm.Speed = rnd.Next(1, 10);
            }

        }
        public void NewGame()
        {
            Stop();
            if (!Init())
            {
                ResetGame();
                Player.SetStartPosition();
            }
            Start();
        }
        public void Start()
        {
            lock (_lock)
            {
                Init();
                if (_timer==null && _timeLeft>0 && _lifes > 0)
                {
                    _timer = new Timer(1000);
                    _timer.Elapsed += (s, e) =>
                    {                     
                        if (--TimeLeft > 0) return;
                        Stop();
                        RaiseEndGame(GameStatus.TimeExpired);
                    };
                    foreach (var worm in _worms)
                        worm.Start();
                    _timer.Start();
                    Status = GameStatus.Running;
                    RaiseStatusChange();
                }

            }
        }
        public void Stop()
        {
            lock (_lock)
            {
                if (Player == null || _timer==null) return;
                _timer.Stop();
                _timer = null;
                foreach(var worm in _worms)
                {
                    worm.Stop();
                
                }
                Status = GameStatus.Waiting;
                RaiseStatusChange();
            }
        }
        public void CheckPlayerPosition(GameObject box)
        {
            if (Player == null || Player == box) return;
            if (
                (
                    (Player.X>=box.X && Player.X<=box.X2)
                    || 
                    (Player.X2>=box.X && Player.X2<=box.X2)             
                )
                &&
                (
                    (Player.Y >= box.Y && Player.Y <= box.Y2)
                    ||
                    (Player.Y2 >= box.Y && Player.Y2 <= box.Y2)
                 )
                )
            {
                KillPlayer();
            }

        }
        private void RaiseEndGame(GameStatus status)
        {
            Status = status;
            EndGame?.Invoke(this, status);
        }
        private void RaiseStatusChange()
        {
            RaisePropertyChanged(nameof(IsRunning));
            RaisePropertyChanged(nameof(IsWaiting));
            RaisePropertyChanged(nameof(IsCommandEnabled));
            RaisePropertyChanged(nameof(CommandName));
        }
    }
}