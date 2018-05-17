using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Joypad : MonoBehaviour {
    //터치패드
    private RectTransform touchPad;
    //플레이어 컨트롤러
    public PlayerController m_PlayerController;
      // 터치 아이디 비활성화 -1
    private int touchID = -1;

    // 시작 위치는 초기화
    private Vector3 startPos = Vector3.zero;

    // 최대 이동 반지름
    public float dragRadius = 130f;

    // 버튼활성화 여부
    private bool buttonPress = false;

	// Use this for initialization
	void Start ()
    {
        // 터치패드 트랜스폼 받아오기
        touchPad = GetComponent<RectTransform>();
        // 시작 위치 저장
        startPos = touchPad.position;

	}
    
    // 눌렀는지 여부 체크 = 활성화
    public void ButtonDown()
    {
        buttonPress = true;
       // transform.localScale = new Vector3(10, 10, 10);
    }
    
    // 버튼을 땟는지 여부 체크  = 비활성화
    public void ButtonUp()
    {
        buttonPress = false;
        HandleInput(startPos);
       //transform.localScale = new Vector3(1, 1, 152);
    }

    // 값의 변화가 있을때만 업데이트
    void FixedUpdate()
    {
        // 핸들 터치
        HandleTouchInput();

        // 구동환경이 유니티 에디터 이거나 OSX 또는 윈도우 마지막으로 웹플레이어라면
#if UNITY_EDITOR || UNITY_STANDALONE_WIN 

        //핸들 인풋은 마우스로 받는다
        if(Input.GetMouseButton(0))
        {
            //ButtonDown();
            HandleInput(Input.mousePosition);
        }
        else
        {
            ButtonUp();
        }
        

#endif

    }

    // 터치 인풋받기
    void HandleTouchInput()
    {
        // 아이디에 넣어줄 값
        int i = 0;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                i++;
                Vector3 touchpos = new Vector3(touch.position.x, touch.position.y);

                if(touch.phase==TouchPhase.Began)
                {
                    if (touch.position.x <=(startPos.x+dragRadius))
                    {
                        touchID = i;

                    }
                    
                }

                else if(touch.phase==TouchPhase.Moved || touch.phase==TouchPhase.Stationary)
                {
                    if (touchID == i)
                    {
                        HandleInput(touchpos);
                    }
                    
                }

                else if(touch.phase == TouchPhase.Ended)
                {
                    if(touchID==i)
                    {
                        touchID = -1;
                    }

                }
            }
        }
    }

    void HandleInput(Vector3 input)
    {
        if (buttonPress)
        {
            Vector3 diffVector = (input - startPos);

            if (diffVector.sqrMagnitude > dragRadius * dragRadius)
            {
                //방향 벡터의 거리를 1로 변환
                diffVector.Normalize();

                //최대 거리에 고정시켜버리기!
                touchPad.position = startPos + diffVector * dragRadius;
            }
            else
            {
                // 그 이외의 상황은 터치받은 곳에 맞게
                touchPad.position = input;
            }
        }
        else
        {
            // 터치가 끝난 상황에서 다시 원상복귀
            touchPad.position = startPos;
        }

        // 시작위치와 터치위치값의 차를 구해 diff라는 곳에 vec3값을 넣는다.
        Vector3 diff = touchPad.position - startPos;

        // diff값을 반지름 만큼 나눠 반지름을 넘어가면 1 또는 -1 을 반환한다. 반환한 값을 통하여 플레이어가 움직일 것이다.
        Vector2 normDiff = new Vector3(diff.x / dragRadius, diff.y / dragRadius);
        // 플레이어가 없지 않다면
        if (m_PlayerController != null)
        {
            // 플레이어 코드에 있는 값이 변경됬다를 시전하고 normDiff 값을 전달한다.
            m_PlayerController.OnVectorChange(normDiff);
        }

    }


}
