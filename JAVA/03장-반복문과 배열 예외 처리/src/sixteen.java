import java.util.Scanner;
public class sixteen {
	public static void program(String man,int com){//0=바위 1=가위 2=보
		if(man.equals("바위")) {
			switch(com) {
			case 0: System.out.println("사용자 = 바위, 컴퓨터 = 바위, 비겼습니다.");break;
			case 1: System.out.println("사용자 = 바위, 컴퓨터 = 가위, 사용자가 이겼습니다.");break;
			case 2: System.out.println("사용자 = 바위, 컴퓨터 = 보, 컴퓨터가 이겼습니다.");break;
			}
		}
		if(man.equals("가위")) {
			switch(com) {
			case 0: System.out.println("사용자 = 가위, 컴퓨터 = 바위, 컴퓨터가 이겼습니다.");break;
			case 1: System.out.println("사용자 = 가위, 컴퓨터 = 가위, 비겼습니다.");break;
			case 2: System.out.println("사용자 = 가위, 컴퓨터 = 보, 사용자가 이겼습니다.");break;
			}
		}
		if(man.equals("보")) {
			switch(com) {
			case 0: System.out.println("사용자 = 보, 컴퓨터 = 바위, 사용자가 이겼습니다.");break;
			case 1: System.out.println("사용자 = 보, 컴퓨터 = 가위, 컴퓨터가 이겼습니다.");break;
			case 2: System.out.println("사용자 = 보, 컴퓨터 = 보, 비겼습니다.");break;
			}
		}
	}
	public static void main(String[]args) {
		Scanner sc=new Scanner(System.in);
		System.out.println("컴퓨터와 가위 바위 보 게임을 합니다.");
		while(true) {
			System.out.print("가위 바위 보!>>");
			String s=sc.next();	
			if(s.equals("그만")) 
				break;			
			int com=(int)Math.random()*3;
			program(s,com);
		}
		System.out.println("게임을 종료합니다...");
		sc.close();
	}
}
