using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace MVRP{
public class Model : MonoBehaviour
{
        // 読み取り専用で ReactiveProperty を公開する（外部からの設定を防ぐことを保証する）
        public IReadOnlyReactiveProperty<int> OnCounterChanged => _counterRp;
        // カプセル化を意識
        // NOTE : ReactiveProperty<int> でも良い．しかしシリアライズ化されないため，Inspector上で表示することが出来ない．
        private IntReactiveProperty _counterRp = new IntReactiveProperty(0);

        //時間の制御
        private DateTime now;
        public IReadOnlyReactiveProperty<int> OnSecondChanged => _second;
        // カプセル化を意識
        // NOTE : ReactiveProperty<int> でも良い．しかしシリアライズ化されないため，Inspector上で表示することが出来ない．
        private IntReactiveProperty _second = new IntReactiveProperty(0);


        /// <summary>
        /// カウンタをインクリメントする
        /// </summary>
        public void IncrementCount()
        {
            _counterRp.Value += 1;
        }
        /// <summary>   
        /// 秒数を更新する
        /// </summary>
        public void updateSecond()
        {
            now = DateTime.Now;
            _second.Value = now.Second;
        }
}
}
