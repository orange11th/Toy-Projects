import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import javax.sound.sampled.*;
import java.io.*;
import java.util.*;

public class eight extends JFrame{
	private JCheckBox[] box=new JCheckBox[3];
	private Clip clip;
	private Vector <String>	v=new Vector<String>();
	public eight() {
		setTitle("오디오 연주");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		
		JPanel jp=new JPanel();
		jp.setBackground(Color.LIGHT_GRAY);
		JLabel jl=new JLabel("체크된 곡만 순서대로 연주합니다.");
		jl.setFont(new Font("Serif",Font.BOLD,13));
		jp.add(jl);
		
		MusicPanel panel=new MusicPanel();
	
		c.add(jp,BorderLayout.NORTH);
		c.add(panel,BorderLayout.CENTER);
		
		setLocation(880,420);
		setSize(400,250);
		setVisible(true);
	}
	class MusicPanel extends JPanel{
		public MusicPanel() {
			setLayout(null);
			for(int i=0;i<3;i++) {
				box[i]=new JCheckBox("0"+(i+1)+".wav");
				box[i].setSize(100,20);
				box[i].setLocation(150,30+30*i);
				box[i].addItemListener(new MyItemListener());
				add(box[i]);
			}
			JButton start=new JButton("연주시작");
			start.setSize(90,30);
			start.setLocation(95,140);
			start.addActionListener(new MyActionListener());
			add(start);
			
			JButton end=new JButton("연주 끝");
			end.setSize(90,30);
			end.setLocation(205,140);
			end.addActionListener(new MyActionListener());
			add(end);
		}	
	}
	private void loadAudio(String pathName) {
		try{
			clip=AudioSystem.getClip();
			File audioFile=new File(pathName);
			AudioInputStream audioStream=AudioSystem.getAudioInputStream(audioFile);
			clip.open(audioStream);
			clip.start();
			clip.addLineListener(new LineListener() {
				@Override
				public void update(LineEvent event) {
					if(event.getType()==LineEvent.Type.START) {
						for(int i=0;i<3;i++) {
							if(pathName.contains(box[i].getText()))
								box[i].setForeground(Color.red);
						}
					}
					if(event.getType()==LineEvent.Type.STOP) {
						for(int i=0;i<3;i++) {
							if(pathName.contains(box[i].getText()))
								box[i].setForeground(Color.black);
						}
						if(v.size()>=1) {loadAudio(v.get(0));}
						else {clip.stop();}
					}
			}});}
		catch(IOException e) {e.printStackTrace();}
		catch(LineUnavailableException e) {e.printStackTrace();}
		catch(UnsupportedAudioFileException e) {e.printStackTrace();}
	}
	class MyItemListener implements ItemListener{				//벡터에 경로 추가
		public void itemStateChanged(ItemEvent e) {
			JCheckBox tmpbox=(JCheckBox) e.getSource();
			if(e.getStateChange()==ItemEvent.DESELECTED) {v.remove("audio/"+tmpbox.getText());}
			else
				v.add("audio/"+tmpbox.getText());
		}		
	}
	class MyActionListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			JButton tmpbtn=(JButton)e.getSource();
			if(tmpbtn.getText().equals("연주시작")) {
					loadAudio(v.get(0));
					v.remove(0);
			}
			else if(tmpbtn.getText().equals("연주 끝")) {v.removeAllElements();clip.stop();}
		}
	}
	public static void main(String[]args) {
		new eight();
	}
}
