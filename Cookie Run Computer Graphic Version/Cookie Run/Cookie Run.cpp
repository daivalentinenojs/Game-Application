// Cookie Run.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <Windows.h>
#include <gl/gl.h>
#include <gl/glut.h>
#include <gl/glu.h>
#include <math.h>
#include <string.h>
#include <cstring>
#include <cstdio>
#include <cstdlib>
#include <iostream>
#include <string>

using namespace std;

/* Deklarasi Ukuran Window */
const int LEFT_WINDOW=0;
const int RIGHT_WINDOW=800;
const int BOTTOM_WINDOW=0;
const int TOP_WINDOW=600;
int obstakle = 0;
/* Deklarasi Timer */
/* t1 = awan1, t2 = awan2, t0 = obstacle, t4 = obstacle2, t3-6 Kapal, 4 & 6 Besar */
float t1 = 0, t2 = 0, t0 = 0, deltaT = 0.01, t3=0, t4 = 0, t5 = 0, t6 = 0;
float tBalon1 = 0, tBalon2 = 0;
float durasi = 10000;
float frameRate = 100;

/* Deklarasi Posisi */
int posisiAwan1 = 100, posisiAwan2=800, posisiObstacle=0, posisiObstacle2=posisiObstacle+750;
int posisiKapal = 500, posisiKapal2 = 100, posisiKapal3 = 250, posisiKapal4 = 50;
int posisiBalon1 = 100, posisiBalon2 = 300;
/* Deklarasi Pergantian Cookie */
int tCookie = 0;

/* Deklarasi Rumus Fisika */
float a = 0.5;
float v0 = 0, yLompat = 0, tLompat = 2;
//float yCookieSekarang = 0;
int aktifLompat = 0;

void DrawAxis(){
	glBegin(GL_LINES);
		glColor3f(1.0,0,0);
			glVertex2f(0,0);
			glVertex2f(800,0);
		glColor3f(0,1.0,0);
			glVertex2f(0,600);
			glVertex2f(0,0);
	glEnd();
}

void DrawCookie1()
{
	/* Kepala Dalam */
	float dt=6.28/360;
	glColor3f(0.9,0.7,0.03);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kepala Luar */
	glColor3f(0,0,0);
	glLineWidth(1.5);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Tangan Kanan */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(98,120+yLompat,0);
	glRotatef(360-150,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kanan */
	glColor3f(0,0,0);
	glTranslatef(98,120+yLompat,0);
	glRotatef(360-150,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Tangan Kiri */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(55,118+yLompat,0);
	glRotatef(150,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kiri */
	glColor3f(0,0,0);
	glTranslatef(55,118+yLompat,0);
	glRotatef(150,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kaki Depan */
	glColor3f(0.9,0.7,0.0);
	glTranslatef(88,79+yLompat,0);
	glRotatef(360-135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Depan */
	glColor3f(0,0,0);
	glTranslatef(88,79+yLompat,0);
	glRotatef(360-135,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Sambungan Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(62,80+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Sambungan Kaki Belakang */
	glColor3f(0,0,0);
	glTranslatef(62,80+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(60,80+yLompat,0);
	glRotatef(75,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Belakang */
	glColor3f(0,0,0);
	glTranslatef(60,80+yLompat,0);
	glRotatef(75,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Badan Kotak */
	glColor3f(0.9,0.7,0.03);
	glBegin(GL_POLYGON);
		glVertex2f(60,80+yLompat);
		glVertex2f(60,120+yLompat);
		glVertex2f(90,120+yLompat);
		glVertex2f(90,80+yLompat);
	glEnd();

	/* Garis Badan Kotak */
	glColor3f(0,0,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(60,88+yLompat);
		glVertex2f(60,108+yLompat);
	glEnd();
	glBegin(GL_LINE_STRIP);
		glVertex2f(90,108+yLompat);
		glVertex2f(90,86+yLompat);
	glEnd();
	glBegin(GL_LINE_STRIP);
		glVertex2f(68,80+yLompat);
		glVertex2f(78,80+yLompat);
	glEnd();

	/* Mata */
	glColor3f(0,0,1.0);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(0,0,1.0);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Mata */
	glColor3f(1,1,1);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1,1,1);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Mulut */
	glColor3f(1.0,0,0);
	glTranslatef(82,135+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=1.57;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Atas Mulut*/
	glColor3f(1.0,0,0);
	glTranslatef(27,95+yLompat,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(50,40);
		glVertex2f(60,40);
	glEnd();
	glLoadIdentity();

	/* Kancing */
	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,110+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,100+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kiri Bawah */
	glColor3f(1,1,1);
	glLineWidth(3);
	glTranslatef(60,155+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=15*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kanan Atas */
	glColor3f(1,1,1);
	glLineWidth(3);
	glTranslatef(81,160+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=3*sin(a);
		float y=10*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();
}

void DrawCookie2()
{
	float dt=6.28/360;
	/* Tangan Kanan */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(98,120+yLompat,0);
	glRotatef(360-180,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kanan */
	glColor3f(0,0,0);
	glTranslatef(98,120+yLompat,0);
	glRotatef(360-180,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Tangan Kiri */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(55,118+yLompat,0);
	glRotatef(180,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kiri */
	glColor3f(0,0,0);
	glTranslatef(55,118+yLompat,0);
	glRotatef(180,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kepala Dalam */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kepala Luar */
	glColor3f(0,0,0);
	glLineWidth(1.5);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kaki Depan */
	glColor3f(0.9,0.7,0.0);
	glTranslatef(81,79+yLompat,0);
	glRotatef(167,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Depan */
	glColor3f(0,0,0);
	glTranslatef(81,79+yLompat,0);
	glRotatef(167,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Sambungan Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(62,80+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Sambungan Kaki Belakang */
	glColor3f(0,0,0);
	glTranslatef(62,80+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(62,80+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Belakang */
	glColor3f(0,0,0);
	glTranslatef(62,80+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Badan Kotak */
	glColor3f(0.9,0.7,0.03);
	glBegin(GL_POLYGON);
		glVertex2f(60,80+yLompat);
		glVertex2f(60,120+yLompat);
		glVertex2f(90,120+yLompat);
		glVertex2f(90,80+yLompat);
	glEnd();

	/* Garis Badan Kotak */
	glColor3f(0,0,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(60,88+yLompat);
		glVertex2f(60,111+yLompat);
	glEnd();
	glBegin(GL_LINE_STRIP);
		glVertex2f(90,111+yLompat);
		glVertex2f(90,80+yLompat);
	glEnd();
	glBegin(GL_LINE_STRIP);
		glVertex2f(68,80+yLompat);
		glVertex2f(78,80+yLompat);
	glEnd();

	/* Mata */
	glColor3f(0,0,1.0);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(0,0,1.0);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Mata */
	glColor3f(1,1,1);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1,1,1);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Mulut */
	glColor3f(1.0,0,0);
	glTranslatef(82,135+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=1.57;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Atas Mulut*/
	glColor3f(1.0,0,0);
	glTranslatef(27,95+yLompat,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(50,40);
		glVertex2f(60,40);
	glEnd();
	glLoadIdentity();

	/* Kancing */
	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,110+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,100+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kiri Bawah */
	glColor3f(1,1,1);
	glLineWidth(3);
	glTranslatef(60,155+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=15*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kanan Atas */
	glColor3f(1,1,1);
	glLineWidth(3);
	glTranslatef(81,160+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=3*sin(a);
		float y=10*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();
}

void DrawCookie3()
{
	/* Tangan Kanan */
	float dt=6.28/360;
	glColor3f(0.9,0.7,0.03);
	glTranslatef(96,110+yLompat,0);
	glRotatef(150,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kanan */
	glColor3f(0,0,0);
	glTranslatef(96,110+yLompat,0);
	glRotatef(150,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Tangan Kiri */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(55,110+yLompat,0);
	glRotatef(360-150,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Tangan Kiri */
	glColor3f(0,0,0);
	glTranslatef(55,110+yLompat,0);
	glRotatef(360-150,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kepala Dalam */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kepala Luar */
	glColor3f(0,0,0);
	glTranslatef(75,142+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=25*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Sambungan Kaki Depan */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(83,80+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Sambungan Kaki Depan */
	glColor3f(0,0,0);
	glTranslatef(84,84+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(75,83+yLompat,0);
	glRotatef(100,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Belakang */
	glColor3f(0,0,0);
	glTranslatef(75,83+yLompat,0);
	glRotatef(100,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=7*cos(a);
		float y=25*sin(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Sambungan Kaki Belakang */
	glColor3f(0.9,0.7,0.03);
	glTranslatef(72,80+yLompat,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=7*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Badan Kotak */
	glColor3f(0.9,0.7,0.03);
	glBegin(GL_POLYGON);
		glVertex2f(60,80+yLompat);
		glVertex2f(60,120+yLompat);
		glVertex2f(90,120+yLompat);
		glVertex2f(90,80+yLompat);
	glEnd();

	/* Garis Badan Kotak */
	glColor3f(0,0,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(60,85+yLompat);
		glVertex2f(60,105+yLompat);
	glEnd();
	glBegin(GL_LINE_STRIP);
		glVertex2f(90,105+yLompat);
		glVertex2f(90,86+yLompat);
	glEnd();

	/* Kaki Depan */
	glColor3f(0.9,0.7,0.0);
	glTranslatef(78,79+yLompat,0);
	glRotatef(360-135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Kaki Depan */
	glColor3f(0,0,0);
	glTranslatef(78,79+yLompat,0);
	glRotatef(360-135,0,0,1);
	glScalef(1,-1,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.7;a+=dt)
	{
		float x=7*sin(a);
		float y=25*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Mata */
	glColor3f(0,0,1.0);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(0,0,1.0);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Mata */
	glColor3f(1,1,1);
	glTranslatef(75,145+yLompat,0);
	glRotatef(235,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1,1,1);
	glTranslatef(90,145+yLompat,0);
	glRotatef(-70,0,0,1);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Mulut */
	glColor3f(1.0,0,0);
	glTranslatef(82,135+yLompat,0);
	glBegin(GL_LINE_STRIP);
	for(float a=1.57;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=5*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Atas Mulut*/
	glColor3f(1.0,0,0);
	glTranslatef(27,95,0);
	glBegin(GL_LINE_STRIP);
		glVertex2f(50,40+yLompat);
		glVertex2f(60,40+yLompat);
	glEnd();
	glLoadIdentity();

	/* Kancing */
	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,110+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	glColor3f(1.0,1.0,1.0);
	glTranslatef(80,100+yLompat,0);
	glRotatef(135,0,0,1);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=3*sin(a);
		float y=3*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kiri Bawah */
	glColor3f(1,1,1);
	glTranslatef(60,155+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=5*sin(a);
		float y=15*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Rambut Kanan Atas */
	glColor3f(1,1,1);
	glTranslatef(81,160+yLompat,0);
	glRotatef(300,0,0,1);
	glBegin(GL_LINE_STRIP);
	for(float a=0;a<=3.14*1.5;a+=dt)
	{
		float x=3*sin(a);
		float y=10*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();
}

void DrawRoad(int plusx, int plusy)
{
	glTranslatef(posisiObstacle,0,0);

	/* Alas Atas */
	glColor3f(1.0,0,0);
	glBegin(GL_POLYGON);
		glVertex2f(0+plusx,45+plusy);	
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(75+plusx,60+plusy);
		glVertex2f(0+plusx,60+plusy);
	glEnd();

	/* Garis Alas Atas */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(0+plusx,45+plusy);	
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(75+plusx,60+plusy);
		glVertex2f(0+plusx,60+plusy);
	glEnd();

	/* Kanan Kiri Pondasi */
	glColor3f(0.9,0.12,0.68);
	glBegin(GL_POLYGON);
		glVertex2f(0+plusx,0+plusy);	
		glVertex2f(0+plusx,45+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(10+plusx,0+plusy);
	glEnd();

	glBegin(GL_POLYGON);
		glVertex2f(75+plusx,0+plusy);
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Garis Kanan Kiri Pondasi */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(0+plusx,0+plusy);	
		glVertex2f(0+plusx,45+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(10+plusx,0+plusy);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glVertex2f(75+plusx,0+plusy);
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Serong Kiri */
	glColor3f(0.9,0.75,0.01);
	glBegin(GL_POLYGON);
		glVertex2f(10+plusx,35+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(65+plusx,10+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Garis Serong Kiri */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(10+plusx,35+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(65+plusx,10+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Serong Kanan */
	glColor3f(0.9,0.75,0.01);
	glBegin(GL_POLYGON);
		glVertex2f(10+plusx,0+plusy);
		glVertex2f(10+plusx,10+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,35+plusy);
	glEnd();

	/* Garis Serong Kanan */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(10+plusx,0+plusy);
		glVertex2f(10+plusx,10+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,35+plusy);
	glEnd();

	glLoadIdentity();

	/* Segitiga */
	glTranslatef(posisiObstacle+140,60,0);
	glBegin(GL_TRIANGLES);
		glColor3f(0.6,0.6,0.6);
		glVertex2f(10,0);
		glVertex2f(40,0);
		glColor3f(1,1,1);
		glVertex2f(25,75);
	glEnd();
	glLoadIdentity();

	/* Garis Segitiga */
	glTranslatef(posisiObstacle+140,60,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
		glVertex2f(10,0);
		glVertex2f(40,0);
		glVertex2f(25,75);
	glEnd();
	glLoadIdentity();

	/* Alas Kotak */
	glTranslatef(posisiObstacle+140,60,0);
	glBegin(GL_POLYGON);
		glColor3f(0.3,0.5,0.5);
		glVertex2f(0,0);
		glVertex2f(50,0);
		glColor3f(0.6,0.6,0.6);
		glVertex2f(50,10);
		glVertex2f(0,10);
	glEnd();
	glLoadIdentity();

	/* Garis Alas Kotak */
	glTranslatef(posisiObstacle+140,60,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
		glVertex2f(0,0);
		glVertex2f(50,0);
		glVertex2f(50,10);
		glVertex2f(0,10);
	glEnd();
	glLoadIdentity();

	/* Buah */
	float dt=6.28/360;
	glColor3f(0.9,0.7,0.03);
	glTranslatef(posisiObstacle+163,100,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0/a+0.2,1/a+0.2,0/a+0.2);
		float x=22*sin(a);
		float y=18*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Buah */
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle+163,100,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=22*sin(a);
		float y=18*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Kiri */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle+156,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Kiri */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle+156,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Kanan */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle+170,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Kanan */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle+170,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Tengah */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle+163,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Tengah */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle+163,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Background Kue Coklat */
	/* Lantai 1 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(0,0);
			glVertex2f(150,0);
			glVertex2f(153,30);
			glVertex2f(0,30);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.6,0);
			glVertex2f(0,30);
			glVertex2f(153,30);
			glVertex2f(156,60);
			glVertex2f(0,60);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(0,60);
			glVertex2f(156,60);
			glVertex2f(158,75);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(0,75);
			glVertex2f(158,75);
			glVertex2f(161,105);
			glVertex2f(0,105);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.6,0);
			glVertex2f(0,105);
			glVertex2f(161,105);
			glVertex2f(164,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Kanan */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(150,0);
			glVertex2f(175,150);
			glVertex2f(164,150);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Atas */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.1,0.8);
			glVertex2f(175,150);
			glVertex2f(162,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Garis Kue Coklat */
	/* Background Kue Coklat */
	/* Lantai 1 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(150,0);
			glVertex2f(153,30);
			glVertex2f(0,30);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,30);
			glVertex2f(153,30);
			glVertex2f(156,60);
			glVertex2f(0,60);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,60);
			glVertex2f(156,60);
			glVertex2f(158,75);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,75);
			glVertex2f(158,75);
			glVertex2f(161,105);
			glVertex2f(0,105);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,105);
			glVertex2f(161,105);
			glVertex2f(164,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Kanan */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(150,0);
			glVertex2f(175,150);
			glVertex2f(164,150);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Atas */
	glTranslatef(posisiObstacle+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(175,150);
			glVertex2f(162,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Background Kue */
	/* Lantai 1 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(80,0);
			glVertex2f(80,20);
			glVertex2f(-3,20);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(-3,20);
			glVertex2f(80,20);
			glVertex2f(80,40);
			glVertex2f(-6,40);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(-6,40);
			glVertex2f(80,40);
			glVertex2f(80,45);
			glVertex2f(-8,45);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,0);
			glVertex2f(-8,45);
			glVertex2f(80,45);
			glVertex2f(80,65);
			glVertex2f(-11,65);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(-11,65);
			glVertex2f(80,65);
			glVertex2f(80,85);
			glVertex2f(-14,85);
	glEnd();
	glLoadIdentity();

	/* Lantai 6 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(-14,85);
			glVertex2f(80,85);
			glVertex2f(80,90);
			glVertex2f(-16,90);
	glEnd();
	glLoadIdentity();

	/* Kue Kiri */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(0,0);
			glVertex2f(-26,100);
			glVertex2f(-14,100);
	glEnd();
	glLoadIdentity();

	/* Kue Atas */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0,0);
			glVertex2f(80,90);
			glVertex2f(-14,90);
			glVertex2f(-26,100);
	glEnd();
	glLoadIdentity();

	/* Garis Background Kue */
	/* Lantai 1 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(80,0);
			glVertex2f(80,20);
			glVertex2f(-3,20);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-3,20);
			glVertex2f(80,20);
			glVertex2f(80,40);
			glVertex2f(-6,40);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-6,40);
			glVertex2f(80,40);
			glVertex2f(80,45);
			glVertex2f(-8,45);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-8,45);
			glVertex2f(80,45);
			glVertex2f(80,65);
			glVertex2f(-11,65);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-11,65);
			glVertex2f(80,65);
			glVertex2f(80,85);
			glVertex2f(-14,85);
	glEnd();
	glLoadIdentity();

	/* Lantai 6 */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-14,85);
			glVertex2f(80,85);
			glVertex2f(80,90);
			glVertex2f(-16,90);
	glEnd();
	glLoadIdentity();

	/* Kue Kiri */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(-26,100);
			glVertex2f(-14,100);
	glEnd();
	glLoadIdentity();

	/* Kue Atas */
	glTranslatef(posisiObstacle+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(80,90);
			glVertex2f(-14,90);
			glVertex2f(-26,100);
	glEnd();
	glLoadIdentity();

	/* Coklat */
	for (int j = 0; j<=200; j+=50)
	{
		for (int i = 0; i<=100; i+=50)
		{
			/* Coklat Dalam */
			glTranslatef(posisiObstacle+560+i,61+j,0);
			glBegin(GL_POLYGON);
				glColor3f(0.5,0,0);
					glVertex2f(0,0);
					glVertex2f(0,50);
					glVertex2f(50,50);
					glVertex2f(50,0);
			glEnd();
			glLoadIdentity();

			glTranslatef(posisiObstacle+570+i,71+j,0);
			glBegin(GL_POLYGON);
				glColor3f(0.8,0.4,0);
					glVertex2f(0,0);
					glVertex2f(0,30);
					glVertex2f(30,30);
					glVertex2f(30,0);
			glEnd();
			glLoadIdentity();

			/* Garis Coklat */
			glTranslatef(posisiObstacle+560+i,61+j,0);
			glBegin(GL_LINE_LOOP);
				glColor3f(0,0,0);
					glVertex2f(0,0);
					glVertex2f(0,50);
					glVertex2f(50,50);
					glVertex2f(50,0);
			glEnd();
			glLoadIdentity();

			glTranslatef(posisiObstacle+570+i,71+j,0);
			glBegin(GL_LINE_LOOP);
				glColor3f(0,0,0);
					glVertex2f(0,0);
					glVertex2f(0,30);
					glVertex2f(30,30);
					glVertex2f(30,0);
			glEnd();
			glLoadIdentity();
		}
	}

	/* Wafer */
	/* Wafer Dalam */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.9,0.8,0.5);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kanan Wafer 1 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,100);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,75);
			glVertex2f(0,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,50);
			glVertex2f(0,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,25);
			glVertex2f(0,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 1 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,100);
			glVertex2f(50,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,75);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,50);
			glVertex2f(50,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,25);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Garis Wafer */
	glTranslatef(posisiObstacle+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Hadiah */
	/* Hadiah Dalam */
	glTranslatef(posisiObstacle+480,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0,1,0);
			glVertex2f(100,50);
			glVertex2f(0,50);	
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();

	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,50);
			glVertex2f(100,50);
			glVertex2f(100,0);
	glEnd();
	glLoadIdentity();
	
	/* Pita Kiri */
	glTranslatef(posisiObstacle+480,61,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kiri */
	glTranslatef(posisiObstacle+480,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Pita Kanan */
	glTranslatef(posisiObstacle+480,61,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kanan */
	glTranslatef(posisiObstacle+480,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Kado Biru */
	/* Kado Dalam */
	glTranslatef(posisiObstacle+675,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0,1);
			glVertex2f(100,125);
			glVertex2f(0,125);	
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(100,125);
			glVertex2f(0,125);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();
	glLoadIdentity();
	
	/* Pita Tengah Vertikal */
	glTranslatef(posisiObstacle+712,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.9,0.1);
			glVertex2f(25,125);
			glVertex2f(0,125);	
			glVertex2f(0,0);
			glVertex2f(25,0);	
	glEnd();
	glLoadIdentity();

	/* Garis Pita Tengah Vertikal */
	glTranslatef(posisiObstacle+712,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,125);
			glVertex2f(0,125);	
			glVertex2f(0,0);
			glVertex2f(25,0);	
	glEnd();
	glLoadIdentity();

	/* Pita Tengah Horizontal */
	glTranslatef(posisiObstacle+675,55,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.9,0.1);
			glVertex2f(100,50);
			glVertex2f(0,50);	
			glVertex2f(0,75);
			glVertex2f(100,75);	
	glEnd();
	glLoadIdentity();

	/* Garis Pita Tengah Horizontal */
	glTranslatef(posisiObstacle+675,55,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(100,50);
			glVertex2f(0,50);	
			glVertex2f(0,75);
			glVertex2f(100,75);	
	glEnd();
	glLoadIdentity();

	/* Pita Kiri */
	glTranslatef(posisiObstacle+675,133,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kiri */
	glTranslatef(posisiObstacle+675,133,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Pita Kanan */
	glTranslatef(posisiObstacle+675,133,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kanan */
	glTranslatef(posisiObstacle+675,133,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Wafer */
	/* Wafer Dalam */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.9,0.8,0.5);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kanan Wafer 1 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,100);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,75);
			glVertex2f(0,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,50);
			glVertex2f(0,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,25);
			glVertex2f(0,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 1 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,100);
			glVertex2f(50,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,75);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,50);
			glVertex2f(50,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,25);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Garis Wafer */
	glTranslatef(posisiObstacle+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();
}

void DrawRoad2(int plusx, int plusy)
{
	glTranslatef(posisiObstacle2,0,0);

	/* Alas Atas */
	glColor3f(1.0,0,0);
	glBegin(GL_POLYGON);
		glVertex2f(0+plusx,45+plusy);	
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(75+plusx,60+plusy);
		glVertex2f(0+plusx,60+plusy);
	glEnd();

	/* Garis Alas Atas */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(0+plusx,45+plusy);	
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(75+plusx,60+plusy);
		glVertex2f(0+plusx,60+plusy);
	glEnd();

	/* Kanan Kiri Pondasi */
	glColor3f(0.9,0.12,0.68);
	glBegin(GL_POLYGON);
		glVertex2f(0+plusx,0+plusy);	
		glVertex2f(0+plusx,45+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(10+plusx,0+plusy);
	glEnd();

	glBegin(GL_POLYGON);
		glVertex2f(75+plusx,0+plusy);
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Garis Kanan Kiri Pondasi */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(0+plusx,0+plusy);	
		glVertex2f(0+plusx,45+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(10+plusx,0+plusy);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glVertex2f(75+plusx,0+plusy);
		glVertex2f(75+plusx,45+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Serong Kiri */
	glColor3f(0.9,0.75,0.01);
	glBegin(GL_POLYGON);
		glVertex2f(10+plusx,35+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(65+plusx,10+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Garis Serong Kiri */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(10+plusx,35+plusy);
		glVertex2f(10+plusx,45+plusy);
		glVertex2f(65+plusx,10+plusy);
		glVertex2f(65+plusx,0+plusy);
	glEnd();

	/* Serong Kanan */
	glColor3f(0.9,0.75,0.01);
	glBegin(GL_POLYGON);
		glVertex2f(10+plusx,0+plusy);
		glVertex2f(10+plusx,10+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,35+plusy);
	glEnd();

	/* Garis Serong Kanan */
	glColor3f(0,0,0);
	glBegin(GL_LINE_LOOP);
		glVertex2f(10+plusx,0+plusy);
		glVertex2f(10+plusx,10+plusy);
		glVertex2f(65+plusx,45+plusy);
		glVertex2f(65+plusx,35+plusy);
	glEnd();

	glLoadIdentity();

	/* Segitiga */
	glTranslatef(posisiObstacle2+140,60,0);
	glBegin(GL_TRIANGLES);
		glColor3f(0.6,0.6,0.6);
		glVertex2f(10,0);
		glVertex2f(40,0);
		glColor3f(1,1,1);
		glVertex2f(25,75);
	glEnd();
	glLoadIdentity();

	/* Garis Segitiga */
	glTranslatef(posisiObstacle2+140,60,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
		glVertex2f(10,0);
		glVertex2f(40,0);
		glVertex2f(25,75);
	glEnd();
	glLoadIdentity();

	/* Alas Kotak */
	glTranslatef(posisiObstacle2+140,60,0);
	glBegin(GL_POLYGON);
		glColor3f(0.3,0.5,0.5);
		glVertex2f(0,0);
		glVertex2f(50,0);
		glColor3f(0.6,0.6,0.6);
		glVertex2f(50,10);
		glVertex2f(0,10);
	glEnd();
	glLoadIdentity();

	/* Garis Alas Kotak */
	glTranslatef(posisiObstacle2+140,60,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
		glVertex2f(0,0);
		glVertex2f(50,0);
		glVertex2f(50,10);
		glVertex2f(0,10);
	glEnd();
	glLoadIdentity();

	/* Buah */
	float dt=6.28/360;
	glColor3f(0.9,0.7,0.03);
	glTranslatef(posisiObstacle2+163,100,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0/a+0.2,1/a+0.2,0/a+0.2);
		float x=22*sin(a);
		float y=18*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Buah */
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle2+163,100,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=22*sin(a);
		float y=18*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Kiri */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle2+156,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Kiri */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle2+156,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Kanan */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle2+170,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Kanan */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle2+170,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Daun Buah Tengah */
	dt=6.28/360;
	glColor3f(0.9,0.9,0.3);
	glTranslatef(posisiObstacle2+163,112,0);
	glBegin(GL_POLYGON);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		glColor3f(0.9,0.9,0.2);
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Garis Daun Buah Tengah */
	dt=6.28/360;
	glColor3f(0,0,0);
	glTranslatef(posisiObstacle2+163,112,0);
	glBegin(GL_LINE_LOOP);
	for(float a=0;a<=3.14*2;a+=dt)
	{
		float x=6*sin(a);
		float y=6*cos(a);
		glVertex2f(x,y);
	}
	glEnd();
	glLoadIdentity();

	/* Background Kue Coklat */
	/* Lantai 1 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(0,0);
			glVertex2f(150,0);
			glVertex2f(153,30);
			glVertex2f(0,30);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.6,0);
			glVertex2f(0,30);
			glVertex2f(153,30);
			glVertex2f(156,60);
			glVertex2f(0,60);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(0,60);
			glVertex2f(156,60);
			glVertex2f(158,75);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(0,75);
			glVertex2f(158,75);
			glVertex2f(161,105);
			glVertex2f(0,105);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.6,0);
			glVertex2f(0,105);
			glVertex2f(161,105);
			glVertex2f(164,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Kanan */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.25,0);
			glVertex2f(150,0);
			glVertex2f(175,150);
			glVertex2f(164,150);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Atas */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.1,0.8);
			glVertex2f(175,150);
			glVertex2f(162,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Garis Kue Coklat */
	/* Background Kue Coklat */
	/* Lantai 1 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(150,0);
			glVertex2f(153,30);
			glVertex2f(0,30);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,30);
			glVertex2f(153,30);
			glVertex2f(156,60);
			glVertex2f(0,60);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,60);
			glVertex2f(156,60);
			glVertex2f(158,75);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,75);
			glVertex2f(158,75);
			glVertex2f(161,105);
			glVertex2f(0,105);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,105);
			glVertex2f(161,105);
			glVertex2f(164,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Kanan */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(150,0);
			glVertex2f(175,150);
			glVertex2f(164,150);
	glEnd();
	glLoadIdentity();

	/* Kue Coklat Atas */
	glTranslatef(posisiObstacle2+300,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(175,150);
			glVertex2f(162,135);
			glVertex2f(0,135);
	glEnd();
	glLoadIdentity();

	/* Background Kue */
	/* Lantai 1 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(80,0);
			glVertex2f(80,20);
			glVertex2f(-3,20);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(-3,20);
			glVertex2f(80,20);
			glVertex2f(80,40);
			glVertex2f(-6,40);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(-6,40);
			glVertex2f(80,40);
			glVertex2f(80,45);
			glVertex2f(-8,45);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,0);
			glVertex2f(-8,45);
			glVertex2f(80,45);
			glVertex2f(80,65);
			glVertex2f(-11,65);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(-11,65);
			glVertex2f(80,65);
			glVertex2f(80,85);
			glVertex2f(-14,85);
	glEnd();
	glLoadIdentity();

	/* Lantai 6 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,1,1);
			glVertex2f(-14,85);
			glVertex2f(80,85);
			glVertex2f(80,90);
			glVertex2f(-16,90);
	glEnd();
	glLoadIdentity();

	/* Kue Kiri */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.7,0);
			glVertex2f(0,0);
			glVertex2f(-26,100);
			glVertex2f(-14,100);
	glEnd();
	glLoadIdentity();

	/* Kue Atas */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0,0);
			glVertex2f(80,90);
			glVertex2f(-14,90);
			glVertex2f(-26,100);
	glEnd();
	glLoadIdentity();

	/* Garis Background Kue */
	/* Lantai 1 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(80,0);
			glVertex2f(80,20);
			glVertex2f(-3,20);
	glEnd();
	glLoadIdentity();

	/* Lantai 2 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-3,20);
			glVertex2f(80,20);
			glVertex2f(80,40);
			glVertex2f(-6,40);
	glEnd();
	glLoadIdentity();

	/* Lantai 3 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-6,40);
			glVertex2f(80,40);
			glVertex2f(80,45);
			glVertex2f(-8,45);
	glEnd();
	glLoadIdentity();

	/* Lantai 4 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-8,45);
			glVertex2f(80,45);
			glVertex2f(80,65);
			glVertex2f(-11,65);
	glEnd();
	glLoadIdentity();

	/* Lantai 5 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-11,65);
			glVertex2f(80,65);
			glVertex2f(80,85);
			glVertex2f(-14,85);
	glEnd();
	glLoadIdentity();

	/* Lantai 6 */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(-14,85);
			glVertex2f(80,85);
			glVertex2f(80,90);
			glVertex2f(-16,90);
	glEnd();
	glLoadIdentity();

	/* Kue Kiri */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(-26,100);
			glVertex2f(-14,100);
	glEnd();
	glLoadIdentity();

	/* Kue Atas */
	glTranslatef(posisiObstacle2+250,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(80,90);
			glVertex2f(-14,90);
			glVertex2f(-26,100);
	glEnd();
	glLoadIdentity();

	/* Coklat */
	for (int j = 0; j<=200; j+=50)
	{
		for (int i = 0; i<=100; i+=50)
		{
			/* Coklat Dalam */
			glTranslatef(posisiObstacle2+560+i,61+j,0);
			glBegin(GL_POLYGON);
				glColor3f(0.5,0,0);
					glVertex2f(0,0);
					glVertex2f(0,50);
					glVertex2f(50,50);
					glVertex2f(50,0);
			glEnd();
			glLoadIdentity();

			glTranslatef(posisiObstacle2+570+i,71+j,0);
			glBegin(GL_POLYGON);
				glColor3f(0.8,0.4,0);
					glVertex2f(0,0);
					glVertex2f(0,30);
					glVertex2f(30,30);
					glVertex2f(30,0);
			glEnd();
			glLoadIdentity();

			/* Garis Coklat */
			glTranslatef(posisiObstacle2+560+i,61+j,0);
			glBegin(GL_LINE_LOOP);
				glColor3f(0,0,0);
					glVertex2f(0,0);
					glVertex2f(0,50);
					glVertex2f(50,50);
					glVertex2f(50,0);
			glEnd();
			glLoadIdentity();

			glTranslatef(posisiObstacle2+570+i,71+j,0);
			glBegin(GL_LINE_LOOP);
				glColor3f(0,0,0);
					glVertex2f(0,0);
					glVertex2f(0,30);
					glVertex2f(30,30);
					glVertex2f(30,0);
			glEnd();
			glLoadIdentity();
		}
	}

	/* Wafer */
	/* Wafer Dalam */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.9,0.8,0.5);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kanan Wafer 1 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,100);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,75);
			glVertex2f(0,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,50);
			glVertex2f(0,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,25);
			glVertex2f(0,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 1 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,100);
			glVertex2f(50,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,75);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,50);
			glVertex2f(50,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,25);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Garis Wafer */
	glTranslatef(posisiObstacle2+450,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Hadiah */
	/* Hadiah Dalam */
	glTranslatef(posisiObstacle2+480,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0,1,0);
			glVertex2f(100,50);
			glVertex2f(0,50);	
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();

	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,50);
			glVertex2f(100,50);
			glVertex2f(100,0);
	glEnd();
	glLoadIdentity();
	
	/* Pita Kiri */
	glTranslatef(posisiObstacle2+480,61,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kiri */
	glTranslatef(posisiObstacle2+480,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Pita Kanan */
	glTranslatef(posisiObstacle2+480,61,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kanan */
	glTranslatef(posisiObstacle2+480,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Kado Biru */
	/* Kado Dalam */
	glTranslatef(posisiObstacle2+675,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0,1);
			glVertex2f(100,125);
			glVertex2f(0,125);	
		glColor3f(1,1,0);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(100,125);
			glVertex2f(0,125);
			glVertex2f(0,0);
			glVertex2f(100,0);	
	glEnd();
	glLoadIdentity();
	
	/* Pita Tengah Vertikal */
	glTranslatef(posisiObstacle2+712,61,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.9,0.1);
			glVertex2f(25,125);
			glVertex2f(0,125);	
			glVertex2f(0,0);
			glVertex2f(25,0);	
	glEnd();
	glLoadIdentity();

	/* Garis Pita Tengah Vertikal */
	glTranslatef(posisiObstacle2+712,61,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,125);
			glVertex2f(0,125);	
			glVertex2f(0,0);
			glVertex2f(25,0);	
	glEnd();
	glLoadIdentity();

	/* Pita Tengah Horizontal */
	glTranslatef(posisiObstacle2+675,55,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0.9,0.1);
			glVertex2f(100,50);
			glVertex2f(0,50);	
			glVertex2f(0,75);
			glVertex2f(100,75);	
	glEnd();
	glLoadIdentity();

	/* Garis Pita Tengah Horizontal */
	glTranslatef(posisiObstacle2+675,55,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(100,50);
			glVertex2f(0,50);	
			glVertex2f(0,75);
			glVertex2f(100,75);	
	glEnd();
	glLoadIdentity();

	/* Pita Kiri */
	glTranslatef(posisiObstacle2+675,133,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kiri */
	glTranslatef(posisiObstacle2+675,133,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(25,35);
			glVertex2f(25,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Pita Kanan */
	glTranslatef(posisiObstacle2+675,133,0);
	glBegin(GL_TRIANGLES);
		glColor3f(1,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Garis Pita Kanan */
	glTranslatef(posisiObstacle2+675,133,0);
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
			glVertex2f(75,35);
			glVertex2f(75,65);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Wafer */
	/* Wafer Dalam */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_POLYGON);
		glColor3f(0.9,0.8,0.5);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kanan Wafer 1 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,100);
			glVertex2f(0,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,75);
			glVertex2f(0,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,50);
			glVertex2f(0,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(50,25);
			glVertex2f(0,0);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 1 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,100);
			glVertex2f(50,75);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 2 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,75);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 3 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,50);
			glVertex2f(50,25);
	glEnd();
	glLoadIdentity();

	/* Silang Kiri Wafer 4 */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0.9,0.6,0.1);
			glVertex2f(0,25);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();

	/* Garis Wafer */
	glTranslatef(posisiObstacle2+760,61,0);
	glBegin(GL_LINE_STRIP);
		glColor3f(0,0,0);
			glVertex2f(0,0);
			glVertex2f(0,100);
			glVertex2f(50,100);
			glVertex2f(50,0);
	glEnd();
	glLoadIdentity();
}

int Kiri = 0;
int Kanan = 800;
int Bawah = 0;
int Atas = 600;
int score = 0;

float scalingFactor = 5;
//int jumlahZI = 0;

void KeyDown(unsigned char key, int x, int y){
	if(key == 'x' || key == 'X')
	{
		// Zoom Out
		if (Kiri < 0 && Bawah < 0 && Kanan > 800 && Atas > 600)
		{
			glViewport(Kiri+scalingFactor,Bawah+scalingFactor,Kanan-(2*scalingFactor),Atas-(2*scalingFactor));
			Kiri += scalingFactor;
			Bawah += scalingFactor;
			Kanan -= 2*scalingFactor;
			Atas -= 2*scalingFactor;
		}
	}
	if(key == 'c' || key == 'C' )
	{
		// Zoom In
		if (Kiri > -75 && Bawah > -75 && Kanan < 950 && Atas < 750)
		{
			glViewport(Kiri-scalingFactor,Bawah-scalingFactor,Kanan+(2*scalingFactor),Atas+(2*scalingFactor));
			Kiri -= scalingFactor;
			Bawah -= scalingFactor;
			Kanan += 2*scalingFactor;
			Atas += 2*scalingFactor;
			//jumlahZI++;
		}
	}
	if(key == 'w' || key == 'W' )
	{
		// Paning Atas
		glViewport(Kiri,Bawah+scalingFactor,Kanan,Atas+scalingFactor);
		Bawah += scalingFactor;
		Atas += scalingFactor;
	}
	if(key == 's' || key == 'S' )
	{
		// Paning Bawah
		glViewport(Kiri,Bawah-scalingFactor,Kanan,Atas-scalingFactor);
		Bawah -= scalingFactor;
		Atas -= scalingFactor;
	}
	if(key == 'd' || key == 'D' )
	{
		// Paning Kanan
		glViewport(Kiri+scalingFactor,Bawah,Kanan+scalingFactor,Atas);
		Kiri += scalingFactor;
		Kanan += scalingFactor;
	}
	if(key == 'a' || key == 'A' )
	{
		// Paning Kiri
		glViewport(Kiri-scalingFactor,Bawah,Kanan-scalingFactor,Atas);
		Kiri -= scalingFactor;
		Kanan -= scalingFactor;
	}
	if(key == 'q' || key == 'Q' )
	{
		// Exit
		exit(0);
	}
	if(key == 'e' || key == 'E' )
	{
		// Back To Normal
		glViewport(0,0,800,600);
		Kiri = 0;
		Bawah = 0;
		Kanan = 800;
		Atas = 600;
	}
	if(key == 'z' || key == 'Z' )
	{
		aktifLompat = 1;
	}
}

void BackgroundLaut()
{
	glScaled(10,10,0);
	glBegin(GL_POLYGON);
		glColor3f(0,1.0,1.0);
			glVertex2f(0,0);
			glVertex2f(80,0);
		glColor3f(0,1.0/3,1.0);
			glVertex2f(80,35);
			glVertex2f(0,35);
	glEnd();
	glLoadIdentity();
}

void BackgroundLangit()
{
	glBegin(GL_POLYGON);
		glColor3f(1.0,1.0,0);			
			glVertex2f(0,600);
			glVertex2f(800,600);
		glColor3f(1.0,0,0);
			glVertex2f(800,350);
			glVertex2f(0,350);
	glEnd();
}

void DrawAwan()
{
	glColor3f(1.0,1.0,1.0);
	float dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan1+i,350,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();

	
	glColor3f(1.0,1.0,1.0);
	dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan1+400+i,450,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		if (i==150)
		{
			glScaled(1.5,1.8,0);
		}
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();

	glColor3f(1.0,1.0,1.0);
	dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan1+125+i,600,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		if (i==150)
		{
			glScaled(1.5,1.8,0);
		}
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();
}

void DrawAwan2()
{
	glColor3f(1.0,1.0,1.0);
	float dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan2+i,350,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();

	
	glColor3f(1.0,1.0,1.0);
	dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan2+400+i,450,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		if (i==150)
		{
			glScaled(1.5,1.8,0);
		}
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();

	glColor3f(1.0,1.0,1.0);
	dt=6.28/360;
	for (int i = 0; i<250;i+=50)
	{
		glTranslatef(posisiAwan2+125+i,600,0);
		if (i==50)
		{
			glScaled(1.5,1.5,0);
		}
		if (i==100)
		{
			glScaled(1.5,2.0,0);
		}
		if (i==150)
		{
			glScaled(1.5,1.8,0);
		}
		glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
		glEnd();
			
		glLoadIdentity();
	}
	glLoadIdentity();
}

int randomYKapal = 50, randomYKapal2 = 100, randomYKapal3 = 225, randomYKapal4 = 175, randomYKapal5 = 75;
int randomYBalon1 = 450, randomYBalon2 = 600;

void Kapal()
{
	glColor3f(1.0,1.0,1.0);
	glTranslatef(201+posisiKapal,randomYKapal+5,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=40*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(125+posisiKapal,randomYKapal,0);
	glBegin(GL_POLYGON);
		glColor3f(1,0,0);			
			glVertex2f(50,0);
			glVertex2f(100,0);
			glVertex2f(125,30);
			glVertex2f(25,30);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(50,0);
			glVertex2f(100,0);
			glVertex2f(125,30);
			glVertex2f(25,30);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(0,1,0);			
			glVertex2f(75,30);
			glVertex2f(100,30);
			glVertex2f(100,50);
			glVertex2f(75,50);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(75,30);
			glVertex2f(100,30);
			glVertex2f(100,50);
			glVertex2f(75,50);
	glEnd();
	glLoadIdentity();
}

void Kapal2()
{
	glColor3f(1.0,1.0,1.0);
	glTranslatef(285+posisiKapal2,randomYKapal2,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=175*sin(a);
				float y=25*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(125+posisiKapal2,randomYKapal2,0);
	glBegin(GL_POLYGON);
		glColor3f(0,0,1);			
			glVertex2f(50,0);
			glVertex2f(300,0);
			glVertex2f(325,75);
			glVertex2f(25,75);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(50,0);
			glVertex2f(300,0);
			glVertex2f(325,75);
			glVertex2f(25,75);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(0,1,0);			
			glVertex2f(75,75);
			glVertex2f(300,75);
			glVertex2f(300,125);
			glVertex2f(75,125);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(75,75);
			glVertex2f(300,75);
			glVertex2f(300,125);
			glVertex2f(75,125);
	glEnd();

	glTranslatef(100,55,0);
	glPushMatrix();
	glBegin(GL_POLYGON);
		glColor3f(1,1,0);			
			glVertex2f(0,30);
			glVertex2f(30,30);
			glVertex2f(30,60);
			glVertex2f(0,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(1,1,0);			
			glVertex2f(50,30);
			glVertex2f(80,30);
			glVertex2f(80,60);
			glVertex2f(50,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(1,1,0);			
			glVertex2f(100,30);
			glVertex2f(130,30);
			glVertex2f(130,60);
			glVertex2f(100,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(1,1,0);			
			glVertex2f(150,30);
			glVertex2f(180,30);
			glVertex2f(180,60);
			glVertex2f(150,60);
	glEnd();
	
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(0,30);
			glVertex2f(30,30);
			glVertex2f(30,60);
			glVertex2f(0,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);				
			glVertex2f(50,30);
			glVertex2f(80,30);
			glVertex2f(80,60);
			glVertex2f(50,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);				
			glVertex2f(100,30);
			glVertex2f(130,30);
			glVertex2f(130,60);
			glVertex2f(100,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(150,30);
			glVertex2f(180,30);
			glVertex2f(180,60);
			glVertex2f(150,60);
	glEnd();
	glPopMatrix();
	glLoadIdentity();
}

void Kapal3()
{
	glColor3f(1.0,1.0,1.0);
	glTranslatef(201+posisiKapal3,randomYKapal3+5,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=40*sin(a);
				float y=20*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(125+posisiKapal3,randomYKapal3,0);
	glBegin(GL_POLYGON);
		glColor3f(0.9,0,0.9);			
			glVertex2f(50,0);
			glVertex2f(100,0);
			glVertex2f(125,30);
			glVertex2f(25,30);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(50,0);
			glVertex2f(100,0);
			glVertex2f(125,30);
			glVertex2f(25,30);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(1,0.5,0);				
			glVertex2f(50,30);
			glVertex2f(75,30);
			glVertex2f(75,50);
			glVertex2f(50,50);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(50,30);
			glVertex2f(75,30);
			glVertex2f(75,50);
			glVertex2f(50,50);
	glEnd();
	glLoadIdentity();
}

void Kapal4()
{
	glColor3f(1.0,1.0,1.0);
	glTranslatef(-25+posisiKapal4,randomYKapal4,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=175*sin(a);
				float y=25*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(125+posisiKapal4,randomYKapal4,0);
	glScalef(-1,1,1);
	glBegin(GL_POLYGON);
		glColor3f(0.8,0.1,0);				
			glVertex2f(50,0);
			glVertex2f(300,0);
			glVertex2f(325,75);
			glVertex2f(25,75);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(50,0);
			glVertex2f(300,0);
			glVertex2f(325,75);
			glVertex2f(25,75);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(1,0.4,0.3);			
			glVertex2f(75,75);
			glVertex2f(300,75);
			glVertex2f(300,125);
			glVertex2f(75,125);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(75,75);
			glVertex2f(300,75);
			glVertex2f(300,125);
			glVertex2f(75,125);
	glEnd();

	glTranslatef(100,55,0);
	glPushMatrix();
	glBegin(GL_POLYGON);
		glColor3f(0.75,0.75,0.75);			
			glVertex2f(0,30);
			glVertex2f(30,30);
			glVertex2f(30,60);
			glVertex2f(0,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(0.75,0.75,0.75);			
			glVertex2f(50,30);
			glVertex2f(80,30);
			glVertex2f(80,60);
			glVertex2f(50,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(0.75,0.75,0.75);			
			glVertex2f(100,30);
			glVertex2f(130,30);
			glVertex2f(130,60);
			glVertex2f(100,60);
	glEnd();

	glBegin(GL_POLYGON);
		glColor3f(0.75,0.75,0.75);			
			glVertex2f(150,30);
			glVertex2f(180,30);
			glVertex2f(180,60);
			glVertex2f(150,60);
	glEnd();
	
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(0,30);
			glVertex2f(30,30);
			glVertex2f(30,60);
			glVertex2f(0,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);				
			glVertex2f(50,30);
			glVertex2f(80,30);
			glVertex2f(80,60);
			glVertex2f(50,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);				
			glVertex2f(100,30);
			glVertex2f(130,30);
			glVertex2f(130,60);
			glVertex2f(100,60);
	glEnd();

	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);			
			glVertex2f(150,30);
			glVertex2f(180,30);
			glVertex2f(180,60);
			glVertex2f(150,60);
	glEnd();
	glPopMatrix();
	glLoadIdentity();
}

void Balon()
{
	glTranslatef(210+posisiBalon1,randomYBalon1,0);
	glBegin(GL_POLYGON);
	glColor3f(0.6,0.4,1);			
			glVertex2f(0,0);
			glVertex2f(5,0);
			glVertex2f(10,50);
			glVertex2f(5,50);
	glEnd();

	glBegin(GL_POLYGON);
	glColor3f(0.6,0.4,1);			
			glVertex2f(-20,0);
			glVertex2f(-25,0);
			glVertex2f(-30,50);
			glVertex2f(-25,50);
	glEnd();
	glLoadIdentity();

	glColor3f(0,0.9,1);	
	glTranslatef(200+posisiBalon1,randomYBalon1+75,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=30*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(210+posisiBalon1,randomYBalon1,0);
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);				
			glVertex2f(0,0);
			glVertex2f(5,0);
			glVertex2f(10,50);
			glVertex2f(5,50);
	glEnd();

	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);			
			glVertex2f(-20,0);
			glVertex2f(-25,0);
			glVertex2f(-30,50);
			glVertex2f(-25,50);
	glEnd();
	glLoadIdentity();

	glTranslatef(200+posisiBalon1,randomYBalon1+75,0);
	dt=6.28/360;
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);	
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=30*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	/* Tempat Orang */
	glTranslatef(187+posisiBalon1,randomYBalon1-25,0);
	glBegin(GL_POLYGON);
	glColor3f(1,0.2,0.4);			
			glVertex2f(0,0);
			glVertex2f(25,0);
			glVertex2f(40,30);
			glVertex2f(-15,30);
	glEnd();
	glLoadIdentity();

	/* Garis Tempat Orang */
	glTranslatef(187+posisiBalon1,randomYBalon1-25,0);
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);			
			glVertex2f(0,0);
			glVertex2f(25,0);
			glVertex2f(40,30);
			glVertex2f(-15,30);
	glEnd();
	glLoadIdentity();
}

void Balon2()
{
	glTranslatef(400+posisiBalon2,randomYBalon2,0);
	glBegin(GL_POLYGON);
	glColor3f(1,0.5,0.1);			
			glVertex2f(0,0);
			glVertex2f(5,0);
			glVertex2f(10,50);
			glVertex2f(5,50);
	glEnd();

	glBegin(GL_POLYGON);
	glColor3f(1,0.5,0.1);			
			glVertex2f(-20,0);
			glVertex2f(-25,0);
			glVertex2f(-30,50);
			glVertex2f(-25,50);
	glEnd();
	glLoadIdentity();

	glColor3f(1,0.1,0.5);	
	glTranslatef(390+posisiBalon2,randomYBalon2+75,0);
	float dt=6.28/360;
	glBegin(GL_POLYGON);
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=30*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	glTranslatef(400+posisiBalon2,randomYBalon2,0);
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);				
			glVertex2f(0,0);
			glVertex2f(5,0);
			glVertex2f(10,50);
			glVertex2f(5,50);
	glEnd();

	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);			
			glVertex2f(-20,0);
			glVertex2f(-25,0);
			glVertex2f(-30,50);
			glVertex2f(-25,50);
	glEnd();
	glLoadIdentity();

	glTranslatef(390+posisiBalon2,randomYBalon2+75,0);
	dt=6.28/360;
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);	
			for(float a=0;a<=3.14*2;a+=dt)
			{
				float x=30*sin(a);
				float y=30*cos(a);
				glVertex2f(x,y);
			}
	glEnd();
	glLoadIdentity();

	/* Tempat Orang */
	glTranslatef(377+posisiBalon2,randomYBalon2-25,0);
	glBegin(GL_POLYGON);
	glColor3f(0.5,1,0.5);			
			glVertex2f(0,0);
			glVertex2f(25,0);
			glVertex2f(40,30);
			glVertex2f(-15,30);
	glEnd();
	glLoadIdentity();

	/* Garis Tempat Orang */
	glTranslatef(377+posisiBalon2,randomYBalon2-25,0);
	glBegin(GL_LINE_LOOP);
	glColor3f(0,0,0);			
			glVertex2f(0,0);
			glVertex2f(25,0);
			glVertex2f(40,30);
			glVertex2f(-15,30);
	glEnd();
	glLoadIdentity();
}

void DrawTitikBantu()
{
	glTranslatef(100,100,0);
	glBegin(GL_POLYGON);
	glColor3f(0,0,0);			
			glVertex2f(0,0);
			glVertex2f(150,0);
			glVertex2f(150,150);
			glVertex2f(0,150);
	glEnd();
	glLoadIdentity();
}

void displayScore( float x, float y, int r, int g, int b, const char *string ) {
	int j = strlen( string );
 
	glColor3f( r, g, b );
	glRasterPos2f( x, y );
	for( int i = 0; i < j; i++ ) {
		glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, string[i] );
	}
}

void write(string text, int x, int y){
    glRasterPos2i(x,y);
    for(int i = 0; i < text.length(); i++){ 
        glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, text.data()[i]);
    }
}

void MyDisplay()
{
	glClear(GL_COLOR_BUFFER_BIT);
	
	BackgroundLangit();
	DrawAwan();
	DrawAwan2();
	BackgroundLaut();
	Balon();
	Balon2();

	Kapal4();
	Kapal2();
	Kapal3();
	Kapal();

	for (int i = 0; i < 800; i+=75)
	{
		DrawRoad(0+i,0);
		DrawRoad2(0+i,0);
	}

	if (tCookie == 1)
	{
		DrawCookie1();
	}
	else if (tCookie == 2)
	{
		DrawCookie2();
	}
	else if (tCookie == 3)
	{
		DrawCookie3();
		tCookie=0;
	}	
	
	displayScore(260, 550, 0, 0, 0, "Created By : 6134059 - Daiva"); 
	//string s = to_string(static_cast<unsigned long long>(score));
	displayScore(650, 550, 0, 0, 0, "Score : ");
	//write(s,735,550);
	DrawAxis();

	glFlush();
}

bool checkKalah ()
{
	
}

int waktu = 0;
void MyTimer(int sebuahNilai)
{
	deltaT = 100.0/frameRate/durasi;
	if (t1 < 1)
		t1 += deltaT;
	if (t2 < 1)
		t2 += deltaT;
	if (t0 < 1)
		t0 += deltaT*5;
	
	if (t3 < 1)
	{
		t3 += deltaT*2;
	
	}

	if (t4 < 1)
	{
		t4 += deltaT*5;
	}
	
	if (t5 < 1)
	{
		t5 += deltaT*5;
	}

	if (t6 < 1)
	{
		t6 += deltaT*20;
	}

	if (tBalon1 < 1)
	{
		tBalon1 += deltaT*1.5;
	}

	if (tBalon2 < 1)
	{
		tBalon2 += deltaT*2;
	}

	tCookie++;
	waktu++;
	if (waktu % 5 == 0)
	{score++;}

	if (posisiAwan1 <= -700)
	{
		posisiAwan1 = 1000;
		t1=0;
	}
	if (posisiAwan2 <= -700)
	{
		posisiAwan2 = 1000;
		t2=0;
	}
	if (posisiKapal <= -700)
	{
		posisiKapal = 1000;
		t3=0;
		randomYKapal = rand()%200+50;
	}
	if (posisiKapal2 <= -700)
	{
		posisiKapal2 = 1000;
		t4=0;
		randomYKapal2 = rand()%100+50;
	}
	if (posisiKapal3 >= 800)
	{
		posisiKapal3 = -1000;
		t5=0;
		randomYKapal3 = rand()%200+100;
	}
	if (posisiKapal4 >= 800)
	{
		posisiKapal4 = -1000;
		t6=0;
		randomYKapal4 = rand()%50+250;
	}

	if (posisiBalon1 >= 800)
	{
		posisiBalon1 = -1000;
		tBalon1=0;
		randomYBalon1 = rand()%185+400;
	}
	if (posisiBalon2 <= -700)
	{
		posisiBalon2 = 1000;
		tBalon2=0;
		randomYBalon2 = rand()%150+350;
	}

	if (posisiObstacle <= -775)
	{
		posisiObstacle = posisiObstacle2;
		posisiObstacle2 = posisiObstacle+750;
		t0=0;
	}

	/* y = (1 - t) * yAwal + t * yAkhir; */
	posisiAwan1 = (1 - t1) * posisiAwan1 + (t1 * 850);
	posisiAwan2 = (1 - t2) * posisiAwan2 + (t2 * 750);
	posisiKapal = (1 - t3) * posisiKapal - (t3 * 850);
	posisiKapal2 = (1 - t4) * posisiKapal2 - (t4 * 850);
	posisiKapal3 = (1 - t5) * posisiKapal3 + (t5 * 850);
	posisiKapal4 = (1 - t6) * posisiKapal4 + (t6 * 850);
	posisiBalon1 = (1 - tBalon1) * posisiBalon1 + (tBalon1 * 850);
	posisiBalon2 = (1 - tBalon2) * posisiBalon2 - (tBalon2 * 850);

	/* Rumus Fisika */
	if (aktifLompat == 1)
	{
		yLompat = v0 * tLompat + 0.5 * a * tLompat * tLompat + 25;
		//yCookieSekarang = yLompat;
		tLompat++;

		if (yLompat >= 150)
		{
			aktifLompat = 2;
			tLompat=0;
		}
	}

	if (aktifLompat == 2)
	{
		yLompat -= v0 + tLompat + 0.5 * a * tLompat * tLompat + 25;
		//yCookieSekarang = yLompat;
		tLompat++;

		if (yLompat <= 0)
		{
			aktifLompat = 0;
			yLompat = 0;
			tLompat = 0;
		}
	}
	posisiObstacle  = (1-t0) * posisiObstacle - (t0 * 900);
	posisiObstacle2 = posisiObstacle+750;
	
	//scoredisplay(200, 300, 0, 0, 0);

	glutPostRedisplay();
	glutTimerFunc(1000/frameRate*3, MyTimer, 1); 
}

int _tmain(int argc, _TCHAR* argv[])
{
	glutInit(&argc, argv);

	char* WAV = "Music.wav";
	sndPlaySound(WAV, SND_ASYNC);

	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800,600);
	glutInitWindowPosition(250,100);

	glutCreateWindow("Escape From The Oven");

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D (LEFT_WINDOW, RIGHT_WINDOW, BOTTOM_WINDOW, TOP_WINDOW);

	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glutDisplayFunc(MyDisplay);

	glutTimerFunc(1000/frameRate*3, MyTimer, 1);
	glutKeyboardFunc(KeyDown);
	glutMainLoop();
	return 0;
}



