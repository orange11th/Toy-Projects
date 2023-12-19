import java.util.Scanner;
public class eight {
	public static void main(String[]args) {
		Scanner sc=new Scanner(System.in);
		 System.out.print("점 (x1,y1)의 좌표를 입력하시오>>");
		 int x1=sc.nextInt();
		 int y1=sc.nextInt();
		 System.out.print("점 (x2,y2)의 좌표를 입력하시오>>");
		int x2=sc.nextInt();
		int y2=sc.nextInt();
		if(((x1<100&x2<100)||(x1>200&&x2>200))||((y1<100&&y2<100||(y1>200&&y2>200))))
			System.out.println("false");
		else
			System.out.println("true");
		sc.close();	
	}
}
