import java.util.Scanner;
import java.io.*;
public class test {
	public static void main(String[]args)  {
		Scanner sc=new Scanner(System.in);
		System.out.println("전체 경로명이 아닌 파일 이름만 입력하는 경우, 파일은 프로젝트 폴더에 있어야 합니다.");
		System.out.print("첫번째 파일 이름을 입력하세요>>");
		String f1=sc.next();
		System.out.print("두번째 파일 이름을 입력하세요>>");
		String f2=sc.next();
		try {
			@SuppressWarnings("resource")
			FileReader fin1=new FileReader(f1);	
			@SuppressWarnings("resource")
			FileReader fin2=new FileReader(f2);
			System.out.println(f1+"와 "+f2+"를 비교합니다.");
			int c1,value=0;
			while((c1=fin1.read())!=-1) {
				if(c1==fin2.read())
					value=1;
		}
		if(value==1)
			System.out.println("파일이 같습니다");
		else
			System.out.println("파일이 서로 다릅니다.");
		} catch (IOException e) {
		System.out.println("입출력 오류");
}
		sc.close();}}
