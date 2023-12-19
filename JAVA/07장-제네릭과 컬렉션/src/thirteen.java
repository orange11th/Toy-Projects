import java.util.HashMap;
import java.util.InputMismatchException;
import java.util.Scanner;
import java.util.Set;
import java.util.Vector;

import java.util.Iterator;
class Supercom{
	private HashMap<String,Integer> h=new HashMap<String,Integer>();
	private Vector<String> v=new Vector<String>();
	private Scanner sc=new Scanner(System.in);
	private void clear() {
		v.removeAllElements();
		h.clear();
	}
	private void start() {
		while(true) {
			Scanner sc=new Scanner(System.in);
			System.out.print(">>");
			String line=sc.nextLine();
			if(line.toUpperCase().equals("GO"))
				break;
			v.add(line);
		}
	}
	private void cal() {
		for(int i=0;i<v.size();i++) {
			try{sc=new Scanner(v.get(i));
			String order=sc.next();
			String obj=sc.next();
			int value=sc.nextInt();
			switch(order) {
			case "mov":mov(obj,value);break;
			case "add":add(obj,value);break;
			case "sub":sub(obj,value);break;
			case "jn0":if((h.get(obj))!=0)
					i=value-1;
					break;
			case "prt":prt(obj,i);
			}}catch(InputMismatchException e) {
				sc=new Scanner(v.get(i));
				String order=sc.next();
				String obj=sc.next();
				String value=sc.next();
				switch(order) {
				case "mov":mov(obj,value);break;
				case "add":add(obj,value);break;
				case "sub":sub(obj,value);break;
				case "jn0":if((h.get(obj))!=0)
						i=jn0(obj,value);
						break;
				case "prt":prt(obj,i);}
		}}
	}
	private <T>int jn0(String s,T i) {return h.get(s);}
	private void mov(String s, int i) {h.put(s,i);}
	private void mov(String s, String i) {h.put(s,h.get(i));}
	private void add(String s, int i) {int tmp=h.get(s);tmp+=i;h.put(s, tmp);}
	private void add(String s, String i) {int tmp=h.get(s);tmp+=h.get(i);h.put(s, tmp);}
	private void sub(String s, int i) {int tmp=h.get(s);tmp-=i;h.put(s, tmp);}
	private void sub(String s, String i) {int tmp=h.get(s);tmp-=h.get(i);h.put(s, tmp);}
	private void prt(String s,int i) {
		Set<String> key=h.keySet();
		Iterator <String> it=key.iterator();
		System.out.println("["+v.get(i)+"]");
		while(it.hasNext()) {
			String tmpkey=it.next();
			System.out.print(tmpkey.toUpperCase()+":"+h.get(tmpkey)+" ");
		}
		System.out.println("\n출력할 결과는 "+h.get(s)+". 프로그램 실행 끝");}
	public void run() {
		System.out.println("수퍼컴이 작동합니다. 프로그램을 입력해주세요. GO를 입력하면 작동합니다.");
		while(true) {
		start();
		cal();
		clear();}}
}
public class thirteen{
	public static void main(String[]args) {
		Supercom sp=new Supercom();
		sp.run();
	}
}