using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
// 프리팹화된 오브젝트를 생성할 오브젝트에 들어갈 코드
public class Example : MonoBehaviour
{
    // 프리팹화된 오브젝트
    public GameObject Obj;

    // 활성화 중인 오브젝트 리스트
    List<GameObject> popList = new List<GameObject>();

    // 풀링을 시켜줄 스크립트
    ObjectPooing pooling = new ObjectPooing();

    // 첫 풀링시 소환할 개수
    int poolingCount = 10;

    private void Awake()
    {
        // *반드시 추가해야함
        // 모든 오브젝트가 활성화 된 상태에서 추가로 생성해 풀링을 시켜주는 기능
        pooling.OnRePooing += PooingObj;

        // PooingObj()로 하셔도 되는데 코드의 통일성을 위해
        // 처음 오브젝트를 생성해 미리 풀링해놓는 과정
        pooling.OnRePooing?.Invoke();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            // 풀링된 오브젝트를 꺼내 생성함(그냥 오브젝트 생성한다고 생각하시면 됩니다)
            CreateObj();
        if (Input.GetButtonDown("Fire2"))
            // 활성화 된 모든 오브젝트 지우기
            RemoveAllObj();
    }     

    // 프리팹화된 오브젝트를 생성해 풀링하는 코드
    void PooingObj()
    {
        for (int i = 0; i < poolingCount; ++i)
        {
            // Instantiate는 매개변수를 다르게 할 수 있어서 원하는 설정 하시면 됩니다
            // 지금은 소환 오브젝트, 부모 오브젝트, 기준 좌표(이건 신경 안쓰셔도 되요)로 구성되어 있습니다
            pooling.Push(Instantiate(Obj, this.transform, false));
        }
    }

    // 풀링된 오브젝트를 생성(활성화) 하는 코드
    // public은 취향입니다
    public void CreateObj()
    {
        GameObject obj = pooling.Pop(transform.position);
        popList.Add(obj);
        Debug.Log("오브젝트가 생성되었습니다");
    }

    // 활성화된 오브젝트를 다시 풀링(비활성화)시키는 코드
    // public을 권장합니다(가능하면 활성화 된 오브젝트 자신이 이 함수를 호출하는 것이 좋기 때문에)
    public void RemoveObj(GameObject obj)
    {
        pooling.Push(obj);
        popList.Remove(obj);
        Debug.Log("오브젝트가 제거되었습니다");
    }

    // 활성화된 모든 오브젝트를 다시 풀링(비활성화)시키는 코드
    // public은 취향입니다
    void RemoveAllObj()
    {
        int cnt = popList.Count;
        for (int i = 0; i < cnt; ++i)
            RemoveObj(popList[0]);
    }

}

// 풀링 방식으로 생성될 프리팹에 들어갈 코드
public class ExampleObj : MonoBehaviour
{
    // 예시) 예를 들기 위한 코드로 꼭 필요하진 않습니다

    // 예시) 시작 위치를 받아둘 위치 벡터
    Vector2 startVec;

    // 예시) 이동 속도
    int speed = 5;

    // 활성화 된 순간에 기능
    private void OnEnable()
    {
        // 예시) 시작 위치를 받아옴
        startVec = transform.position;
    }
    private void Update()
    {
        // 예시) 이동 속도만큼 왼쪽으로 이동
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 예시) 처음 위치에서 일정 거리만큼 멀어지면 발동
        if ((startVec - (Vector2)transform.position).sqrMagnitude > 2f)
            // 중요! 조건 만족 후 삭제
            // 생성하는 오브젝트를 부모로 하는 방법으로 해서 GetComponentInParent을 사용했습니다
            // 만약, 생성하는 오브젝트를 부모로 하지 않았다면 GameObject.FindGameObjectWithTag("") 또는
            // Example 컴퍼넌트를 소유한 오브젝트를 찾는 다른 방식을 사용해야합니다.
            GetComponentInParent<Example>().RemoveObj(gameObject);        
    }
}
*/
public class ObjectPooing
{
    Queue<GameObject> poolingObj = new Queue<GameObject>();

    // 풀링 안에 남아있지 않을 때, 빼려하면 나타나는 액션
    public UnityAction OnRePooing;

    // 풀링에 추가하는 용도
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        poolingObj.Enqueue(obj);
        
    }

    // 풀링에서 빼는 용도
    public GameObject Pop(Vector3 pos = new Vector3(), Vector3 rotate = new Vector3())
    {
        if(0 == poolingObj.Count)
        {
            OnRePooing?.Invoke();
        }
        GameObject obj = poolingObj.Dequeue();
        if (Vector3.zero == pos)
            pos = obj.transform.position;
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.Euler(rotate);
        return obj;
    }

}
