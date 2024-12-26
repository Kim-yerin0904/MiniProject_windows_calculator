using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MiniProject_windows_calculator
{
    public partial class Calculator : Form
    {
        //구조체 만들기
        struct ErrorMessages
        {
            public string ZeroDivisionErrorMessage;
            public string ExceptErrorMessage;
        }

        ErrorMessages error = new ErrorMessages();

        //클래스 인스턴스 생성
        ClearFunction clearFunction = new ClearFunction(); //전역변수 초기화용
        UnaryOperations unaryOperations = new UnaryOperations();
        AdditionalFunction additionalFunction = new AdditionalFunction();
        NumberButtons numberButtons = new NumberButtons();

        //변수
        string recentlyInput; // 숫자면 num, 연산자면 oper, =일때는 =

        public Calculator()
        {
            InitializeComponent();
            RHS_Output.Text = "0";
            error.ZeroDivisionErrorMessage = "0으로 나눌 수 없습니다.";
        }

        // %버튼
        private void Modulo_Click(object sender, EventArgs e)
        {
            //현재 값 검사 후 숫자가 있으면 가져와서 % 함수 실행
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string[] result = new string[2];
                result = unaryOperations.Percent(RHS_Output.Text, LHS_Output.Text);
                RHS_Output.Text = result[0];
                LHS_Output.Text = result[1];
                past_operator = '_';
            }
            //값이 없다면 아무 실행 X
        }

        //분수 버튼(1/x)
        private void Fraction_Click(object sender, EventArgs e)
        {
            //현재 값 검사 후 숫자가 있으면 가져와서 분수 함수 실행
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string[] result = unaryOperations.Fraction(RHS_Output.Text, LHS_Output.Text);
                RHS_Output.Text = result[0];
                if (past_operator == '=')
                {
                    LHS_Output.Text = "";
                    LHS_Output.Text = result[1];
                }
                else
                {
                    LHS_Output.Text = result[1];
                }
                past_operator = '_';
            }
            //값이 없다면 아무 실행 X
        }

        //제곱 버튼 x^2
        private void SQR_Click(object sender, EventArgs e)
        {
            //현재 값 검사 후 숫자가 있으면 가져와서 제곱 함수 실행
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string[] result = unaryOperations.Square(RHS_Output.Text, LHS_Output.Text);
                RHS_Output.Text = result[0];
                LHS_Output.Text = result[1];
                past_operator = '_';
            }
            //값이 없다면 아무 실행 X
        }

        //제곱근 버튼 
        private void SquareRoot_Click(object sender, EventArgs e)
        {
            //현재 값 검사 후 숫자가 있으면 가져와서 제곱근 함수 실행
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string[] result = unaryOperations.Root(RHS_Output.Text, LHS_Output.Text);
                RHS_Output.Text = result[0];
                LHS_Output.Text = result[1];
                past_operator = '_';
            }
            //값이 없다면 아무 실행 X
        }

        //소수점 버튼
        private void DecimalPoint_Click(object sender, EventArgs e)
        {
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string result = additionalFunction.DecimalPoint(RHS_Output.Text);
                RHS_Output.Text = result;
                past_operator = '_';
            }
        }

        //음수양수로 바꾸기
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            //현재 값 검사 후 숫자가 있으면 가져와서 음수양수 함수 실행
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                string result = unaryOperations.NegativePositive(RHS_Output.Text);
                RHS_Output.Text = result;
                past_operator = '_';
            }
            //값이 없다면 아무 실행 X
        }

        //화살표 함수 (람다식)
        //CE 버튼 (최근항목 삭제)
        private void CE_Click(object sender, EventArgs e)=> RHS_Output.Text = "0";

        //C 버튼 (전체 삭제)
        private void C_Click(object sender, EventArgs e)
        {
            RHS_Output.Text = "0";
            LHS_Output.Text = "";
            recentlyInput = "";
        }

        // 백스페이스 버튼
        private void Delete_Click(object sender, EventArgs e) => RHS_Output.Text = clearFunction.BackspaceButton(RHS_Output.Text);

        //숫자 0 버튼
        private void Zero_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.ZeroButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text= result[1]; 
            recentlyInput = "num";
        }

        // 숫자 1 버튼
        private void One_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.OneButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        //숫자 2버튼
        private void Two_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.TwoButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        // 숫자 3버튼
        private void Three_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.ThreeButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        //숫자 4버튼
        private void Four_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.FourButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        // 숫자 5버튼
        private void Five_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.FiveButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        // 숫자 6버튼
        private void Six_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.SixButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        // 숫자 7버튼
        private void Seven_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.SevenButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        // 숫자 8버튼
        private void Eight_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.EightButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        //숫자 9버튼
        private void Nine_Click(object sender, EventArgs e)
        {
            string[] result = numberButtons.NineButton(RHS_Output.Text, LHS_Output.Text, recentlyInput);
            RHS_Output.Text = result[0];
            LHS_Output.Text = result[1];
            recentlyInput = "num";
        }

        private char past_operator = '='; // 이전 연산자 확인에 사용
        // 나누기 버튼
        private void Division_Click(object sender, EventArgs e)
        {
            // 피연산자 값(숫자)을 입력하지 않았거나 오류로 값이 사라진 상황에선 연산 실행 생략
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                ElementaryArithmetic elementaryArithmetic = new ElementaryArithmetic();
                // 수식에 추가할 항(수식 + 피연산자 연산자)
                LHS_Output.Text = elementaryArithmetic.division(LHS_Output.Text, RHS_Output.Text, past_operator);
                past_operator = '÷';
                recentlyInput = "oper";
            }
        }
        // 곱하기 버튼
        private void Multiplication_Click(object sender, EventArgs e)
        {
            // 피연산자 값(숫자)을 입력하지 않았거나 오류로 값이 사라진 상황에선 연산 실행 생략
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                ElementaryArithmetic elementaryArithmetic = new ElementaryArithmetic();
                // 수식에 추가할 항(수식 + 피연산자 연산자)
                LHS_Output.Text = elementaryArithmetic.multiplication(LHS_Output.Text, RHS_Output.Text, past_operator);
                past_operator = '×';
                recentlyInput = "oper";
            }
        }
        // 빼기 버튼
        private void Subtraction_Click(object sender, EventArgs e)
        {
            // 피연산자 값(숫자)을 입력하지 않았거나 오류로 값이 사라진 상황에선 연산 실행 생략
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                ElementaryArithmetic elementaryArithmetic = new ElementaryArithmetic();
                // 수식에 추가할 항(수식 + 피연산자 연산자)
                LHS_Output.Text = elementaryArithmetic.subtraction(LHS_Output.Text, RHS_Output.Text, past_operator);
                past_operator = '−';
                recentlyInput = "oper";
            }
        }
        // 더하기 버튼
        private void Addition_Click(object sender, EventArgs e)
        {
            // 피연산자 값(숫자)을 입력하지 않았거나 오류로 값이 사라진 상황에선 연산 실행 생략
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                ElementaryArithmetic elementaryArithmetic = new ElementaryArithmetic();
                // 수식에 추가할 항(수식 + 피연산자 연산자)
                LHS_Output.Text = elementaryArithmetic.addition(LHS_Output.Text, RHS_Output.Text, past_operator);
                past_operator = '+';
                recentlyInput = "oper";
            }
        }
        // = 버튼. 수식의 계산값 출력
        private void Assignment_Click(object sender, EventArgs e)
        {
            // 피연산자 값(숫자)을 입력하지 않았거나 오류로 값이 사라진 상황에선 연산 실행 생략
            if (RHS_Output.Text != "" && RHS_Output.Text != error.ZeroDivisionErrorMessage)
            {
                ElementaryArithmetic elementaryArithmetic = new ElementaryArithmetic();
                string result = elementaryArithmetic.assignment(LHS_Output.Text, RHS_Output.Text, past_operator);
                if (past_operator == '_')
                    LHS_Output.Text = RHS_Output.Text + " = ";
                else
                    LHS_Output.Text += RHS_Output.Text + " = ";
                RHS_Output.Text = result;
                past_operator = '=';
                recentlyInput = "=";
            }
        }
        // LHS_Output창에 직접 입력(커서) 방지
        private void LHS_Output_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        // RHS_Output창에 숫자, 백스페이스, 소수점 이외 직접 입력(커서) 방지
        private void RHS_Output_KeyPress(object sender, KeyPressEventArgs e)
        {
            // RHS 출력값이 "0"(아무것도 입력 X)한 상태일 때 공백으로 수정. 0이 맨 앞으로 가는 상황 방지
            if (RHS_Output.Text == "0")
            {
                RHS_Output.Text = "";
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
        private void RHS_Output_Enter(object sender, EventArgs e)
        {
            // RHS 출력값이 ""(모든 입력값 삭제)한 상태일 때 "0"으로 수정. RHS 출력값이 완전히 비는 상황 방지
            if (RHS_Output.Text == "")
            {
                RHS_Output.Text = "0";
            }
            // 커서가 항상 오른쪽 끝에 위치하도록 고정
            RHS_Output.SelectionStart = RHS_Output.Text.Length;
        }
    }
}