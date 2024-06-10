using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVRP{
public class Presenter : MonoBehaviour
{
    [SerializeField] private Model model;
    [SerializeField] private View view;
    void Awake()
    {
        // delegate Ver
        // ViewのDelegateをセット
        view.OnCountChanged += model.IncrementCount;
        // ModelのObservableを購読し，Viewの表示を更新
        model.OnCounterChanged.Subscribe(_count => view.DisplayCounter(_count));
        // ModelのObservableを購読し，Viewの表示を更新
        model.OnSecondChanged.Subscribe(_second => debugTime(_second));
    }
    void Update(){
        //秒数を常時更新
        model.updateSecond();
    }
    private void debugTime(int _second)
    {
        Debug.Log($"Second: {_second}");
    }
}
}