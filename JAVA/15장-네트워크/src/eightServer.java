import javax.swing.*;
import java.awt.*;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

class eightServer extends JFrame{
	private Socket socket=null;
	private ServerSocket listener=null;
	private JTextArea ja=new JTextArea();
	private JLabel imageLabel=new JLabel();
	private File file;
	public eightServer() {
		setTitle("파일 받는 서버");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		ja.setBorder(BorderFactory.createLineBorder(Color.black,1));
		c.add(ja,BorderLayout.NORTH);
		
		c.add(imageLabel,BorderLayout.CENTER);
		
		setSize(300,300);
		setLocation(880,420);
		setVisible(true);

		try {
			listener=new ServerSocket(9999);
			while(true) {
			socket=listener.accept();
			ja.append("연결됨\n");
			rcvProgram pro =new rcvProgram(socket);
			pro.start();
			}
		}catch(IOException e) {
			System.out.println(e.getMessage());
		}finally {
			try {
				socket.close();
				listener.close();
			}catch(IOException e) {
				System.out.println("오류 발생");
			}
		}
		}
	class rcvProgram extends Thread{
		Socket socket;
		public rcvProgram(Socket socket) {
			this.socket=socket;
		}
	public void run(){
		try {
		BufferedReader in=new BufferedReader(new InputStreamReader(socket.getInputStream()));
		String name=in.readLine();
		file=new File("copy_"+name);
		ja.append("전송받을 파일 이름 길이: "+name.getBytes().length+"\n");
		ja.append("전송받은 파일 이름: "+name+"\n");	
		ja.append("저장할 파일 이름: "+file.getName()+"\n");
		}
		catch(IOException e){System.out.println(e.getMessage());}
		try {
		DataInputStream dis=new DataInputStream(socket.getInputStream());
		FileOutputStream fo=new FileOutputStream(file);
		while(true) {
			byte[]buffer=new byte[1024];
			while(true) {
				int n=dis.read(buffer);
				fo.write(buffer,0,n);
				if(n<buffer.length)
					break;
			}
			ja.append("전송받은 파일 크기:"+file.length()+"\n.............................................................................\n");
			ja.append("파일 수신 성공. 현재 폴더에 저장되었습니다\n");
			
			ImageIcon icon=new ImageIcon(file.getName());
			imageLabel.setIcon(icon);
			pack();
			
			dis.close();
			fo.close();
		}}
	catch(IOException e) {System.out.println(e.getMessage());}}}
	public static void main(String[]args) {
		new eightServer();
	}
}