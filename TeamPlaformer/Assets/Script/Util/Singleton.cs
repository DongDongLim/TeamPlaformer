using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글톤을 사용할때 이 클래스를 상속받게 하고 T안에 스크립트 이름을 넣어주면 됩니다
// 처음에 빨간줄이 뜨는 이유는 OnAwake를 재정의 하지 않아서 입니다
// 현재 Awake가 싱글톤을 구현하기 위해 사용되기 때문에 상속 받은 자식 클래스에서는 Awake를 사용하면 안됩니다
// OnAwake()는 반드시 정의해야하며 여기에 사용된 내용이 Awake라고 보시면 됩니다
// protected override void OnAwake() { 안의 내용은 비워도셔도 됩니다 }
// 상속받은 자식만 접근이 가능하도록 protected로 만들었습니다
public abstract class Singleton<T> : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (null == _instance)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(this);
        }
        OnAwake();
    }

    protected abstract void OnAwake();

}
