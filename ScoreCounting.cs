using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounting : MonoBehaviour
{
    [SerializeField] Image _marker;
    [SerializeField] Text _txtCount;
    [SerializeField] Text _txtScore;

    int _targetScore = 0;
    float _drawScore = 0;
    float _countingTime = 1.5f;
    bool _isCount = false;
    bool _isItemCount = false;
    ResultWnd _ownerRef;

    public int _calceScore
    {
        get { return _targetScore; }
    }

    public bool _endCounting
    {
        get { return !_isCount; }
    }

    private void Start()
    {
        //InitDataSet(DefineHelper.eInsectKind.GreenInsect, 20);
    }

    private void LateUpdate()
    {
        if(_isCount)
        {
            if (_targetScore <= _drawScore)     //총점이 드로우스코어보다 작거나 같으면
            {
                _txtScore.text = _targetScore.ToString();
                _isCount = false;
                //_ownerRef.CheckCounting();
                //스코어카운트가 끝났는지 검사를 여기서 실행?
            }
            else            //총점이 드로우스코어보다 크면
            {
                _drawScore += _targetScore * (Time.deltaTime / _countingTime);      //정해준 시간동안 드로우스코어 올림
                _txtScore.text = ((int)_drawScore).ToString();                      //드로우스코어를 점수Txt에 입력
            }
        }
        if (_isItemCount)
        {
            if (_targetScore >= _drawScore)     //총점이 드로우스코어보다 작거나 같으면
            {
                _txtScore.text = _targetScore.ToString();
                _isItemCount = false;
                //_ownerRef.CheckCounting();
                //스코어카운트가 끝났는지 검사를 여기서 실행?
            }
            else            //총점이 드로우스코어보다 크면
            {
                _drawScore += _targetScore * (Time.deltaTime / _countingTime);      //정해준 시간동안 드로우스코어 올림
                _txtScore.text = ((int)_drawScore).ToString();                      //드로우스코어를 점수Txt에 입력
            }
        }
    }
    public void InitDataSet(DefineHelper.eInsectKind kind, int killCnt, ResultWnd owner)
    {
        _ownerRef = owner;              //ResultWindow를 사용하기 위해 Init에서 받아온다.
        _marker.sprite = ResoucePoolManager._instance.GetInsectTypeIcon(kind);          //marker이미지를 가져온다.
        _txtCount.text = killCnt.ToString();                                        //죽인 횟수를 입력한다.
        _txtScore.text = "0";                                                       //스코어를 0으로 초기화
        _targetScore = killCnt * DefineHelper._baseScorePerInsect[(int)kind];       //targetScore에 죽인수 * 점수
        _isCount = true;                                                            //카운트를 시작시킨다.
    }
    public void InitDataSet(DefineHelper.eSelectItemKind kind, int UseCnt, ResultWnd owner)
    {
        _ownerRef = owner;              //ResultWindow를 사용하기 위해 Init에서 받아온다.
        _marker.sprite = ResoucePoolManager._instance.GetItemSpriteFromType(kind);          //marker이미지를 가져온다.
        _txtCount.text = UseCnt.ToString();                                        //죽인 횟수를 입력한다.
        _txtScore.text = "0";                                                       //스코어를 0으로 초기화
        _targetScore = -(UseCnt * DefineHelper._useItemScore);       //targetScore에 죽인수 * 점수
        _isItemCount = true;                                                            //카운트를 시작시킨다.
    }
}
