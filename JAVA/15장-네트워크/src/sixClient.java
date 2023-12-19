import java.io.*;
import java.net.*;
import java.util.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class sixClient extends JFrame{
	private JTextField jt1=new JTextField(8);
	private JTextField jt2=new JTextField(8);
	private Socket socket=null;	
	public sixClient() {	
		
		setLayout(new FlowLayout());
		add(new JLabel("영어"));
		add(jt1);
		add(new JLabel("한글"));
		add(jt2);
		JButton btn=new JButton("찾기");
		add(btn);
		
		try {
			socket=new Socket("localhost",9999);
		}catch(IOException e) {
			System.out.println(e.getMessage());}
		btn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					BufferedReader in=new BufferedReader(new InputStreamReader(socket.getInputStream()));
					BufferedWriter out=new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
					out.write(jt1.getText()+"\n");
					out.flush();
					String result=in.readLine();
					jt2.setText(result);
				}catch(IOException e1) {System.out.println(e1.getMessage());}
			}		
		});
		setTitle("클라이언트");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocation(1080,420);
		setSize(400,150);
		setVisible(true);	
	}
	public static void main(String[]args) {
		new sixClient();
	}
}