package YabadabaDu;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;


import javax.swing.JPanel;
import javax.swing.Timer;

@SuppressWarnings("serial")
public class Gameplay extends JPanel implements KeyListener,ActionListener{
	
	private boolean play=false;
	private int score=0;
	private int totalbricks=21;
	private Timer time;
	private int delay=6;
	private int player=310;
	private int ballposX=120;
	private int ballposY=350;
	private int balldirX=-1;
	private int balldirY=-2;
	
	public Gameplay() {
		addKeyListener(this);
		setFocusable(true);
		setFocusTraversalKeysEnabled(false);
		time=new Timer(delay,this);
		time.start();		
	}
	public void paint(Graphics g) {
		g.setColor(Color.BLACK);
		g.fillRect(1, 1, 700, 600);
		
		//Borders
		g.setColor(Color.YELLOW);
		g.fillRect(0, 0, 3, 592);
		g.fillRect(0, 0, 692, 3);
		g.fillRect(691, 0, 3, 592);
		
		//paddle
		g.setColor(Color.GREEN);
		g.fillRect(player, 550, 100, 8);
		
		//ball
		g.setColor(Color.CYAN);
		g.fillOval(ballposX	,ballposY, 20,20);
		
		
	}
	public void keyPressed(KeyEvent e) {
		if(e.getKeyCode()==KeyEvent.VK_RIGHT) {
			if(player>=600) {
				player=600;
			}
			else
			{
				moveRight();
			}
			
		}
		if(e.getKeyCode()==KeyEvent.VK_LEFT) {
			if(player<0) {
				player=10;
			}
			else
			{
				moveLeft();
			}
		}	
	}
	public void moveRight() {
		play=true;
		player+=20;
	}
	public void moveLeft() {
		play=true;
		player-=20;
	}
	
	

	public void actionPerformed(ActionEvent arg0) {
		time.start();
		if(play) {
  			if (new Rectangle(ballposX,ballposY,20,20).intersects(new Rectangle(player,550,100,0))) {
				balldirY=-balldirY;
			}
			
			ballposX+=balldirX;
			ballposY+=balldirY;
			if(ballposX<0) {
				balldirX=-balldirX;
			}
			if(ballposY<0) {
				balldirY=-balldirY;
			}
			if(ballposX>670) {
				balldirX=-balldirX;
			}
			
		}
		repaint();
		
	}
	public void keyReleased(KeyEvent arg0) {}
	public void keyTyped(KeyEvent arg0) {}	

}
