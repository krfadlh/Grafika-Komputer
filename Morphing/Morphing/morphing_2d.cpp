//#include <stdafx.h>
#include <stdlib.h>
#include <windows.h>
#include <glut.h>
typedef struct {
	float r;
	float g;
	float b;
} color_t;
int a = 0, b = 0, c = 0, d = 0;

//Rumus interpolasi linier
int rumus1(int x1, int x2, int y1, int y2, int x) {
	int y = (x*(y2 - y1) + x2*y1 - x1*y2) / (x2 - x1);
	return y;
}
void setColor(float red, float green, float blue)
{
	glColor3f(red, green, blue);
}
void warnai(color_t col)
{
	glColor3f(col.r, col.g, col.b);
}
void tampilkan() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glClearColor(0.2, 0.1, 0.3, 0);
	static float color_iterate = 0;
	color_t warna = { 0.5,0.8,0.1 };
	warna.r = color_iterate;
	glLoadIdentity();
	glBegin(GL_QUADS);
	warnai(warna);
	glVertex2d(2 + a, rumus1(2, 3, 4, 6, 2 + a));
	glVertex2d(6 + b, rumus1(6, 10, 4, 14, 6 + b));
	glVertex2d(6 + c, 1);
	glVertex2d(2, 1 + d);
	glEnd();
	glFlush();
	Sleep(600);
	if (1 + a <3) {
		a++;
		color_iterate += 0.2;
	}
	if (5 + b <10) {
		b++;
		color_iterate += 0.5;
	}
	if (6 + c <15) {
		c++;
		color_iterate -= 0.4;
	}
	if (1 + d <2) {
		d++;
		color_iterate += 0.3;
	}
}
void init(void)
{
	glMatrixMode(GL_PROJECTION);
	gluOrtho2D(0, 20, 0, 20);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}
int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(500, 500); //Ukuran window
	glutCreateWindow("Morphing - 2110151055");
	glutDisplayFunc(tampilkan);
	init();
	glutIdleFunc(tampilkan);
	glutMainLoop();
	return 0;
}