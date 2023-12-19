import java.util.*;
import java.io.*;
public class twelve {
	public static void main(String[]args) {
		Vector<String> v=new Vector<String>();
		Scanner sc=new Scanner(System.in);
		System.out.println("전체 경로명이 아닌 파일 이름만 입력하는 경우, 파일은 프로젝트 폴더에 있어야 합니다.");
		System.out.print("대상 파일명 입력>> ");
		String name=sc.nextLine();
		try {
			FileReader fin=new FileReader(name);
			@SuppressWarnings("resource")
			BufferedReader bf=new BufferedReader(fin);
			String line="";
			while((line=bf.readLine())!=null) {
				v.add(line);
			}
		while(true){
			System.out.print("검색할 단어나 문장>> ");
			String src=sc.nextLine();
			if(src.equals("그만"))
				break;
			for(int i=0;i<v.size();i++) {
				if(v.get(i).contains(src))
						System.out.println((int)i+1+":"+v.get(i));
			}
		}
		} catch (IOException e) {
			System.out.println("파일이 없습니다.");
		}
		sc.close();
		System.out.println("프로그램을 종료합니다.");
}}
