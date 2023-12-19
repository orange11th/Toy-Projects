import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.util.List;
import java.util.ArrayList;
import java.util.Arrays;

public class Main extends JFrame {
	protected Container c;
	protected JTextField JTrNum, JTnum, JTCalc;
	protected JTextField[] JT;
	protected JButton input, add, calc;
	protected JRadioButton DV, Dijkstra, RIP, IGRP, OSPF;
	protected JRadioButton[] JB;
	protected String[] labels = { "출발노드,인접노드,metric(음수O)", "출발노드,인접노드,metric", "출발노드,인접노드(홉 수로 계산)", 
			"출발노드,인접노드,대역폭,지연","출발노드,인접노드,대역폭,지연" };
	protected String[] JBName = { "거리 벡터", "다익스트라", "RIP", "IGRP", "OSPF" };
	protected JLabel introduce, name, select, search, JLrNum, JLnum, jl;
	protected RouterDialog dialog;
	protected Dijkstra d;
	protected Bellman_Ford b;
	protected int rNum, num, flag;
	protected JTextArea JA;
	protected ArrayList<String> ansList;
	protected List<Edge> edges;
	// 화면 크기 가져옴
	Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
	double Displaywidth = screenSize.getWidth();
	double Displayheight = screenSize.getHeight();
	// 프로그램 크기 설정
	int SizeX = 800;
	int SizeY = 600;

	public Main() {
		setTitle("라우팅 시뮬레이터");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		c = getContentPane();

		c.setLayout(null);

		// 프로그램 소개 Y=15~45
		introduce = new JLabel("라우팅 시뮬레이터");
		introduce.setFont(new Font("SansSerif", Font.BOLD, 30));
		introduce.setBounds(240, 15, 300, 30);
		c.add(introduce);
		// 이름 학번
		name = new JLabel("B889056 이효재");
		name.setFont(new Font("SansSerif", Font.BOLD, 13));
		name.setBackground(Color.pink);
		name.setOpaque(true);
		name.setBounds(520, 32, 100, 13);
		c.add(name);
		// 라디오 버튼 설명
		select = new JLabel("라우팅 프로토콜을 선택하세요.");
		select.setFont(new Font("SansSerif", Font.BOLD, 15));
		select.setBounds(260, 70, 300, 15);
		c.add(select);
		// 라디오버튼 생성
		ButtonGroup group = new ButtonGroup();// 버튼 그룹 객체 생성
		JB = new JRadioButton[5];
		for (int i = 0; i < JB.length; i++) {
			JB[i] = new JRadioButton(JBName[i]);
			group.add(JB[i]);
			JB[i].addItemListener(new MyItemListener());
			JB[i].setBounds(100 + 120 * i, 90, 100, 30);
			c.add(JB[i]);
		}
		// 라우터 개수 입력 설명
		JLrNum = new JLabel("노드 개수(최대 8개):");
		JLrNum.setFont(new Font("SansSerif", Font.BOLD, 15));
		JLrNum.setBounds(160, 130, 140, 15);
		JLrNum.setVisible(false);
		c.add(JLrNum);
		// 라우터 개수 입력 칸
		JTrNum = new JTextField(10);
		JTrNum.setBounds(300, 130, 60, 15);
		JTrNum.setVisible(false);
		c.add(JTrNum);
		// 간선 개수 입력 설명
		JLnum = new JLabel("간선 개수:");
		JLnum.setFont(new Font("SansSerif", Font.BOLD, 15));
		JLnum.setBounds(380, 130, 70, 15);
		JLnum.setVisible(false);
		c.add(JLnum);
		// 간선 개수 입력 칸
		JTnum = new JTextField(10);
		JTnum.setBounds(450, 130, 60, 15);
		JTnum.setVisible(false);
		c.add(JTnum);

		input = new JButton("입력");
		input.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					num = Integer.parseInt(JTnum.getText());
				} catch (NumberFormatException e1) {
					num = 0;
					rNum=0;
				}
				try {
					rNum = Integer.parseInt(JTrNum.getText());
				} catch (NumberFormatException e1) {
					rNum = 0;
					num=0;
				}
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
				dialog = new RouterDialog(num);
				dialog.setVisible(true);
			}
		});
		input.setBounds(520, 130, 60, 15);
		input.setVisible(false);
		c.add(input);

		search = new JLabel("경로를 검색할 노드( , 로 중복 입력 가능)");
		search.setBounds(155, 170, 300, 15);
		search.setFont(new Font("SansSerif", Font.BOLD, 15));
		search.setVisible(false);
		c.add(search);

		JTCalc = new JTextField(15);
		JTCalc.setBounds(430, 170, 80, 15);
		JTCalc.setVisible(false);
		c.add(JTCalc);

		calc = new JButton("검색");
		calc.setBounds(515, 170, 60, 15);
		calc.addActionListener(new calcActionListener());
		calc.setVisible(false);
		c.add(calc);

		JA = new JTextArea();
		JA.setFont(new Font("SansSerif", Font.BOLD, 20));
		JScrollPane scrollPane = new JScrollPane(JA);
		scrollPane.setBounds(50, 200, 685, 330);
		c.add(scrollPane);

		setResizable(false);
		setLocation(((int) Displaywidth - SizeX) / 2, ((int) Displayheight - SizeY) / 2);// 프로그램 화면 중앙 출력
		setSize(SizeX, SizeY);
		setVisible(true);
	}

	// 라디오버튼 리스너
	class MyItemListener implements ItemListener {
		public void itemStateChanged(ItemEvent e) {
			if (e.getStateChange() == ItemEvent.DESELECTED)
				return;
			JLrNum.setVisible(true);
			JTrNum.setVisible(true);
			JLnum.setVisible(true);
			JTnum.setVisible(true);
			input.setVisible(true);
			if (JB[0].isSelected()) {// 거리 벡터
				flag = 0;
				JTrNum.setText("");
				JTnum.setText("");
				JA.setText("");
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
			} else if (JB[1].isSelected()) {// 다익스트라
				flag = 1;
				JTrNum.setText("");
				JTnum.setText("");
				JA.setText("");
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
			} else if (JB[2].isSelected()) {// RIP
				flag = 2;
				JTrNum.setText("");
				JTnum.setText("");
				JA.setText("");
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
			} else if (JB[3].isSelected()) {// IGRP
				flag = 3;
				JTrNum.setText("");
				JTnum.setText("");
				JA.setText("");
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
			} else if (JB[4].isSelected()) {// OSPF
				flag = 4;
				JTrNum.setText("");
				JTnum.setText("");
				JA.setText("");
				search.setVisible(false);
				JTCalc.setVisible(false);
				calc.setVisible(false);
			}
		}
	}

	// 다이어그램
	class RouterDialog extends JDialog {
		String[] s = { "입력 없음" };

		public RouterDialog(int num) {
			setTitle("소문자로 입력! ex) a,b,5");
			setLayout(new FlowLayout());
			jl = new JLabel(labels[flag]);

			jl.setFont(new Font("Serif", Font.BOLD, 15));
			add(jl);
			JT = new JTextField[num];
			for (int i = 0; i < JT.length; i++) {
				JT[i] = new JTextField(15);
				add(JT[i]);
			}
			JButton btn = new JButton("입력");
			btn.addActionListener(new MyActionListener());
			add(btn);

			if (num == 0||rNum==0) {
				jl.setText(s[0]);
				btn.setText("돌아가기");
			}
			setSize(250, 100 + num * 30);
			setLocation(((int) Displaywidth - 250) / 2, ((int) Displayheight - (100 + num * 30)) / 2);
		}
	}

	// 다이어그램 버튼 리스너
	class MyActionListener implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			if(num==0||rNum==0) {
				dialog.setVisible(false);
				return;}
			// TODO Auto-generated method stub
			JA.setText("");
			JTCalc.setText("");
			switch (flag) {
			case 0:
				try {
					edges = new ArrayList<Edge>();
					for (int i = 0; i < num; i++) {
						Scanner sc = new Scanner(JT[i].getText()).useDelimiter(",");
						edges.add(
								new Edge((int) sc.next().charAt(0) - 97, (int) sc.next().charAt(0) - 97, sc.nextInt()));
					}
				} catch (Exception e2) {
					dialog.setVisible(false);
					break;
				}
				dialog.setVisible(false);
				search.setVisible(true);
				JTCalc.setVisible(true);
				calc.setVisible(true);
				break;
			case 1:
				try {
					d = new Dijkstra(rNum);
					ArrayList<st> struct = new ArrayList<st>();
					for (int i = 0; i < num; i++) {
						Scanner sc = new Scanner(JT[i].getText()).useDelimiter(",");
						struct.add(new st(sc.next(), sc.next(), sc.nextInt()));
						d.input(struct.get(i).source, struct.get(i).destination, struct.get(i).metric);
					}
				} catch (Exception e2) {
					dialog.setVisible(false);
					break;
				}
				dialog.setVisible(false);
				search.setVisible(true);
				JTCalc.setVisible(true);
				calc.setVisible(true);
				break;
			case 2://RIP
				try {
					edges = new ArrayList<Edge>();
					String s1,s2;
					for (int i = 0; i < num; i++) {
						Scanner sc = new Scanner(JT[i].getText()).useDelimiter(",");
						s1=sc.next();
						s2=sc.next();
						edges.add(new Edge((int) s1.charAt(0) - 97, s2.charAt(0) - 97, 1));
						edges.add(new Edge((int) s2.charAt(0) - 97, s1.charAt(0) - 97, 1));
					}
				} catch (Exception e2) {
					dialog.setVisible(false);
					break;
				}
				dialog.setVisible(false);
				search.setVisible(true);
				JTCalc.setVisible(true);
				calc.setVisible(true);
				break;
			case 3:
				try {
					edges = new ArrayList<Edge>();
					String s1,s2;
					int i1,bandwidth,delay;
					for (int i = 0; i < num; i++) {
						Scanner sc = new Scanner(JT[i].getText()).useDelimiter(",");
						s1=sc.next();
						s2=sc.next();
						bandwidth=sc.nextInt();
						delay=sc.nextInt();
						if(bandwidth==0||delay==0)
							i1=0;
						else
							i1=(int) Math.pow(10, 7) / bandwidth + delay / 10;
						edges.add(new Edge((int) s1.charAt(0) - 97, s2.charAt(0) - 97, i1));
						edges.add(new Edge((int) s2.charAt(0) - 97, s1.charAt(0) - 97, i1));
					}
				} catch (Exception e2) {
					dialog.setVisible(false);
					break;
				}
				dialog.setVisible(false);
				search.setVisible(true);
				JTCalc.setVisible(true);
				calc.setVisible(true);
				break;
			case 4:
				try {
					d = new Dijkstra(rNum);
					ArrayList<st> struct = new ArrayList<st>();
					String s1,s2;
					int i1,bandwidth,delay;
					for (int i = 0; i < num; i++) {
						Scanner sc = new Scanner(JT[i].getText()).useDelimiter(",");
						s1=sc.next();
						s2=sc.next();
						bandwidth=sc.nextInt();
						delay=sc.nextInt();
						if(bandwidth==0||delay==0)
							i1=1;
						else
							i1=(int) Math.pow(10, 7) / bandwidth + delay / 10;
						struct.add(
								new st(s1, s2, i1));
						d.input(struct.get(i).source, struct.get(i).destination, struct.get(i).metric);
					}
				} catch (Exception e2) {
					dialog.setVisible(false);
					break;
				}
				dialog.setVisible(false);
				search.setVisible(true);
				JTCalc.setVisible(true);
				calc.setVisible(true);
				break;
			}
		}
	}

	// 계산 버튼 리스너
	class calcActionListener implements ActionListener {
		private Scanner sc;

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			JA.setText("");
			switch (flag) {
			case 0:
				b = new Bellman_Ford();
				sc = new Scanner(JTCalc.getText()).useDelimiter(",");
				while (sc.hasNext()) {
					b.bellmanFord(edges, (int) sc.next().charAt(0) - 97, rNum);
					ansList = b.getList();
					int size = ansList.size();
					for (int i = 0; i < size; i++) {
						JA.append(ansList.get(i) + "\n");
					}
					JA.append(" =======================================================\n");
				}
				break;
			case 1:
				sc = new Scanner(JTCalc.getText()).useDelimiter(",");
				while (sc.hasNext()) {
					d.algorithm(sc.next());
					ansList = d.getList();
					int size = ansList.size();
					for (int i = 0; i < size; i++) {
						JA.append(ansList.get(i) + "\n");
					}
					JA.append(" =======================================================\n");
				}
				break;
			case 2:
				b = new Bellman_Ford();
				sc = new Scanner(JTCalc.getText()).useDelimiter(",");
				while (sc.hasNext()) {
					b.bellmanFord(edges, (int) sc.next().charAt(0) - 97, rNum);
					ansList = b.getList();
					int size = ansList.size();
					for (int i = 0; i < size; i++) {
						JA.append(ansList.get(i) + "\n");
					}
					JA.append(" =======================================================\n");
				}
				break;
			case 3:
				b = new Bellman_Ford();
				sc = new Scanner(JTCalc.getText()).useDelimiter(",");
				while (sc.hasNext()) {
					b.bellmanFord(edges, (int) sc.next().charAt(0) - 97, rNum);
					ansList = b.getList();
					int size = ansList.size();
					for (int i = 0; i < size; i++) {
						JA.append(ansList.get(i) + "\n");
					}
					JA.append(" =======================================================\n");
				}
				break;
			case 4:
				sc = new Scanner(JTCalc.getText()).useDelimiter(",");
				while (sc.hasNext()) {
					d.algorithm(sc.next());
					ansList = d.getList();
					int size = ansList.size();
					for (int i = 0; i < size; i++) {
						JA.append(ansList.get(i) + "\n");
					}
					JA.append(" =======================================================\n");
				}
				break;
			}
		}
	}

	class st {
		String source;
		String destination;
		int metric;

		protected st(String s, String d, int i) {
			this.source = s;
			this.destination = d;
			this.metric = i;
		}
	}

	public static void main(String[] args) {
		new Main();
	}
}