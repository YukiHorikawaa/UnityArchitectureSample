using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace MVRP
{
public class View : MonoBehaviour
{
        [SerializeField] private Button button;
        [SerializeField] private Text textCounter;
        //delegate Ver 関数ポインタのようなもの
        public delegate void Action ();
        public Action OnCountChanged ;

        // //UniRx Ver （Unitは発火機能のみを持つUnirxの型）
        // public IObservable<Unit> OnCountAsObservable() => _onCountTrigger;
        // private readonly Subject<Unit> _onCountTrigger = new Subject<Unit>();

        private void Awake()
        {
            // Buttonを参照する
            button.onClick.AddListener(delegate { OnCountChanged(); });
            // button
            //     // ボタンが押下された時
            //     .OnClickAsObservable()
            //     // 購読し，カウンタを実行するイベントを発行する
            //     .Subscribe(_ => _onCountTrigger.OnNext(Unit.Default))
            //     .AddTo(this);
            //delegate をセット
        }

        /// <summary>
        /// カウンタ表示用のメソッド
        /// </summary>
        /// <param name="count"></param>
        public void DisplayCounter(int count)
        {
            textCounter.text = $"Counter: {count}";
        }
    }
}
