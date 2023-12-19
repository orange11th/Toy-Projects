import java.io.*;
import java.net.*;
import java.util.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class fiveClient extends JFrame{
	private JTextField jt=new JTextField(10);
	private JLabel label=new JLabel();
	private Socket socket=null;	
	public fiveClient() {	
		
		setLayout(new FlowLayout());
		add(new JLabel("이름 입력"));
		add(jt);
		add(label);
		
		try {
			socket=new Socket("localhost",9999);
		}catch(IOException e) {
			System.out.println(e.getMessage());}
		jt.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					BufferedReader in=new BufferedReader(new InputStreamReader(socket.getInputStream()));
					BufferedWriter out=new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
					out.write(jt.getText()+"\n");
					out.flush();
					String result=in.readLine();
					label.setText(result);
				}catch(IOException e1) {System.out.println(e1.getMessage());}
			}		
		});
		setTitle("스펠체크 클라이언트");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocation(1080,420);
		setSize(400,150);
		setVisible(true);	
	}
	public static void main(String[]args) {
		new fiveClient();
	}
}