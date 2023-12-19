import java.io.*;
public class Test {
	public static void main(String[]args) {
		File src=new File("images\\12.jpg");
		File dest=new File("12_copy.jpg");
		
		try {
			FileInputStream fi=new FileInputStream(src);
			FileOutputStream fo=new FileOutputStream(dest);
			byte[]buf=new byte[1024*10];
			while(true) {
				int n=fi.read(buf);
				fo.write(buf,0,n);
				if(n<buf.length)
					break;
			}
			fi.close();
			fo.close();
		}catch(IOException e) {System.out.println(e.getMessage());}
	}
}
