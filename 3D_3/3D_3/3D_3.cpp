// kubus.cpp : Defines the entry point for the console application.
// Program grafik 3D
#include <glut.h>
#include <math.h>

typedef struct {
	float x, y;
} point2D_t;

typedef struct {
	float x, y, z;
} point3D_t;

typedef struct {
	float v[4];
} vector3D_t;

typedef struct {
	float m[4][4];
} matrix3D_t;

typedef struct {
	float r, g, b;
} color_t;

vector3D_t point2vector(point3D_t pnt)
{
	vector3D_t vec;
	vec.v[0] = pnt.x;
	vec.v[1] = pnt.y;
	vec.v[2] = pnt.z;
	vec.v[3] = 1.;
	return vec;
}

point3D_t vector2point(vector3D_t vec)
{
	point3D_t pnt;
	pnt.x = vec.v[0];
	pnt.y = vec.v[1];
	pnt.z = vec.v[2];
	return pnt;
}

point2D_t vector2point2D(vector3D_t vec)
{
	point2D_t pnt;
	pnt.x = vec.v[0];
	pnt.y = vec.v[1];
	return pnt;
}

matrix3D_t createIdentity(void) {
	matrix3D_t u;
	int i, j;
	for (i = 0; i<4; i++) {
		for (j = 0; j<4; j++) u.m[i][j] = 0.;
		u.m[i][i] = 1.;
	}
	return u;
}

matrix3D_t translationMTX(float dx, float dy, float dz) {
	matrix3D_t T = createIdentity();
	T.m[0][3] = dx;
	T.m[1][3] = dy;
	T.m[2][3] = dz;
	return T;
}

matrix3D_t rotationZMTX(float theta)
{
	matrix3D_t rotate = createIdentity();
	float cs = cos(theta);
	float sn = sin(theta);
	rotate.m[0][0] = cs; rotate.m[0][1] = -sn;
	rotate.m[1][0] = sn; rotate.m[1][1] = cs;
	return rotate;
}

matrix3D_t rotationYMTX(float theta)
{
	matrix3D_t rotate = createIdentity();
	float cs = cos(theta);
	float sn = sin(theta);
	rotate.m[0][0] = cs; rotate.m[0][2] = -sn;
	rotate.m[2][0] = sn; rotate.m[2][2] = cs;
	return rotate;
}

matrix3D_t rotationXMTX(float theta)
{
	matrix3D_t rotate = createIdentity();
	float cs = cos(theta);
	float sn = sin(theta);
	rotate.m[1][1] = cs; rotate.m[1][2] = -sn;
	rotate.m[2][1] = sn; rotate.m[2][2] = cs;
	return rotate;
}

matrix3D_t scalingMTX(float sx, float sy, float sz) {
	matrix3D_t S = createIdentity();
	S.m[0][0] = sx;
	S.m[1][1] = sy;
	S.m[2][2] = sz;
	return S;
}

matrix3D_t operator * (matrix3D_t a, matrix3D_t b)
{
	matrix3D_t c;//c=a*b
	int i, j, k;
	for (i = 0; i<4; i++) for (j = 0; j<4; j++) {
		c.m[i][j] = 0;
		for (k = 0; k<4; k++)
			c.m[i][j] += a.m[i][k] * b.m[k][j];
	}
	return c;
}

vector3D_t operator * (matrix3D_t a, vector3D_t b)
{
	vector3D_t c;//c=a*b
	int i, j;
	for (i = 0; i<4; i++) {
		c.v[i] = 0;
		for (j = 0; j<4; j++)
			c.v[i] += a.m[i][j] * b.v[j];
	}
	return c;
}
vector3D_t operator ^ (vector3D_t a, vector3D_t b)
{
	vector3D_t c;//c=a*b
	c.v[0] = a.v[1] * b.v[2] - a.v[2] * b.v[1];
	c.v[1] = a.v[2] * b.v[0] - a.v[0] * b.v[2];
	c.v[2] = a.v[0] * b.v[1] - a.v[1] * b.v[0];
	c.v[3] = 1.;
	return c;
}
vector3D_t operator - (vector3D_t v1, vector3D_t v0)
{
	vector3D_t c;//c=v1-v0
	c.v[0] = v1.v[0] - v0.v[0];
	c.v[1] = v1.v[1] - v0.v[1];
	c.v[2] = v1.v[2] - v0.v[2];
	c.v[3] = 1.;
	return c;
}

vector3D_t operator - (vector3D_t v)
{
	vector3D_t c;//c=-v
	c.v[0] = -v.v[0];
	c.v[1] = -v.v[1];
	c.v[2] = -v.v[2];
	c.v[3] = 1.;
	return c;
}

void setColor(float r, float g, float b) {
	glColor3f(r, g, b);
}

void setColor(color_t col) {
	glColor3f(col.r, col.g, col.b);
}

void drawDot(float x, float y) {
	glBegin(GL_POINTS);
	glVertex2f(x, y);
	glEnd();
}

void drawDot(point2D_t p) {
	glBegin(GL_POINTS);
	glVertex2f(p.x, p.y);
	glEnd();
}

void drawLine(float x1, float y1, float x2, float y2) {
	glBegin(GL_LINES);
	glVertex2f(x1, y1);
	glVertex2f(x2, y2);
	glEnd();
}

void drawLine(point2D_t p1, point2D_t p2) {
	glBegin(GL_LINES);
	glVertex2f(p1.x, p1.y);
	glVertex2f(p2.x, p2.y);
	glEnd();
}

void drawPolygon(point2D_t p[], int n) {
	glBegin(GL_LINE_LOOP);
	for (int i = 0; i<n; i++) glVertex2f(p[i].x, p[i].y);
	glEnd();
}

void gradatePolygon(point2D_t p[], color_t col[], int n) {
	glBegin(GL_POLYGON);
	for (int i = 0; i<n; i++) {
		glColor3f(col[i].r, col[i].g, col[i].b);
		glVertex2f(p[i].x, p[i].y);
	}
	glEnd();
}

void fillPolygon(point2D_t p[], color_t col, int n) {
	setColor(col);
	glBegin(GL_POLYGON);
	for (int i = 0; i<n; i++) glVertex2f(p[i].x, p[i].y);
	glEnd();
}

void drawPolyline(point2D_t p[], int n) {
	glBegin(GL_LINE_STRIP);
	for (int i = 0; i<n; i++) glVertex2f(p[i].x, p[i].y);
	glEnd();
}

static void createCircle(point2D_t p[], float r) {
	for (int i = 0; i<360; i++) {
		p[i].x = r*cos(i / 57.3);
		p[i].y = r*sin(i / 57.3);
	}
}

static void createCircle(point2D_t p[], float r[]) {
	for (int i = 0; i<360; i++) {
		p[i].x = r[i] * cos(i / 57.3);
		p[i].y = r[i] * sin(i / 57.3);
	}
}

//////////////////////////////////////////////////////////////////
void drawcharX(float x, float y)
{
	drawLine(x, y, x + 10, y + 12);
	drawLine(x, y + 12, x + 10, y);
}

void drawcharY(float x, float y)
{
	drawLine(x + 5, y, x + 5, y + 7);
	drawLine(x, y + 12, x + 5, y + 7);
	drawLine(x + 10, y + 12, x + 5, y + 7);
}

void drawcharZ(float x, float y)
{
	drawLine(x, y + 12, x + 10, y + 12);
	drawLine(x + 10, y + 12, x, y);
	drawLine(x, y, x + 10, y);
}

void drawAxes(matrix3D_t view)
{
#define HALFAXIS  220
#define HALFAXIS1 (HALFAXIS-10)
	point3D_t axes[14] = {
		{ -HALFAXIS,0,0 },{ HALFAXIS,0,0 },{ HALFAXIS1,5,0 },{ HALFAXIS1,0,0 },{ 0,0,0 },
		{ 0,-HALFAXIS,0 },{ 0,HALFAXIS,0 },{ 0,HALFAXIS1,5 },{ 0,HALFAXIS1,0 },{ 0,0,0 },
		{ 0,0,-HALFAXIS },{ 0,0,HALFAXIS1 },{ 5,0,HALFAXIS1 },{ 0,0,HALFAXIS1 }
	};
	vector3D_t vec[14];
	point2D_t buff[14];
	int i;
	for (i = 0; i<14; i++) {
		vec[i] = point2vector(axes[i]);
		vec[i] = view*vec[i];
		buff[i] = vector2point2D(vec[i]);
	}
	drawPolyline(buff, 14);
	drawcharX(buff[1].x, buff[1].y);
	drawcharY(buff[6].x, buff[6].y);
	drawcharZ(buff[11].x - 14, buff[11].y);
}

typedef struct {
	int NumberofVertices;
	int pnt[32];
	//color_t colface;
} face_t;

typedef struct {
	int NumberofVertices;
	point3D_t pnt[100];
	int NumberofFaces;
	face_t fc[50];
} object3D_t;

void draw3D(object3D_t obyek, color_t col, matrix3D_t mat)
{
	vector3D_t vec[1000], vecbuff[360], NormalVector;
	float normalzi;
	point2D_t titik2D[360];

	int i, j;
	// Transformasi terhadap semua titik
	for (i = 0; i<obyek.NumberofVertices; i++) {
		vec[i] = point2vector(obyek.pnt[i]);
		vec[i] = mat*vec[i];
	}
	/*	// Menggambar setiap face
	for(i=0;i<obyek.NumberofFaces;i++){
	for(j=0;j<obyek.fc[i].NumberofVertices;j++){
	vecbuff[j]=vec[obyek.fc[i].pnt[j]];
	titik2D[j]=vector2point2D(vecbuff[j]);
	}
	drawPolygon(titik2D,obyek.fc[i].NumberofVertices);
	}(*/

	//face invisible 
	setColor(1, 1, 1);
	for (i = 0; i<obyek.NumberofFaces; i++) {
		for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
			vecbuff[j] = vec[obyek.fc[i].pnt[j]];
		NormalVector = (vecbuff[1] - vecbuff[0]) ^ (vecbuff[2] - vecbuff[0]);
		normalzi = NormalVector.v[2];
		if (normalzi<0.)
		{
			for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
				titik2D[j] = vector2point2D(vec[obyek.fc[i].pnt[j]]);
			fillPolygon(titik2D, col, obyek.fc[i].NumberofVertices);
			setColor(1, 1, 1);
			drawPolygon(titik2D, obyek.fc[i].NumberofVertices);
		}
	}
	//face visible
	setColor(1, 1, 1);
	for (i = 0; i<obyek.NumberofFaces; i++) {
		for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
			vecbuff[j] = vec[obyek.fc[i].pnt[j]];
		NormalVector = (vecbuff[1] - vecbuff[0]) ^ (vecbuff[2] - vecbuff[0]);
		normalzi = NormalVector.v[2];
		if (normalzi>0.)
		{
			for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
				titik2D[j] = vector2point2D(vec[obyek.fc[i].pnt[j]]);
			drawPolygon(titik2D, obyek.fc[i].NumberofVertices);
		}
	}

}

void userdraw() {
	static float dtick = 0.5, timeTick = 200, tick = 50;
	static float tick1a = 50, tick2a = 50, tick3a = 50, tick4a = 50, tick5a = 50, tick6a = 50, tick7a = 50, tick8a = 50, tick9a = 50;
	static float tick1b = 50, tick2b = 50, tick3b = 50, tick4b = 50, tick5b = 50, tick6b = 50, tick7b = 50, tick8b = 50, tick9b = 50;
	static float tick1c = 50, tick2c = 50, tick3c = 50, tick4c = 50, tick5c = 50, tick6c = 50, tick7c = 50, tick8c = 50, tick9c = 50;

	matrix3D_t mat;
	matrix3D_t tilting = rotationXMTX(0.5)*rotationYMTX(0.5);
	//matrix3D_t tilting=createIdentity();
	setColor(0, 0, 1);
	//drawAxes(tilting);

	color_t merah = { 1,0,0 };
	color_t kuning = { 1,1,0 };
	color_t hijau = { 0,1,0 };

	object3D_t kubus = { 8,{ { 100,100,100 },{ 100,100,-100 },{ -100,100,-100 },{ -100,100,100 },{ 100,-100,100 },{ 100,-100,-100 },{ -100,-100,-100 },{ -100,-100,100 } },6,
	{ { 4,{ 0,3,7,4 } },{ 4,{ 1,5,6,2 } },{ 4,{ 0,4,5,1 } },{ 4,{ 2,6,7,3 } },{ 4,{ 0,1,2,3 } },{ 4,{ 4,7,6,5 } } } };
	//draw3D(kubus,tilting);

	//============================================================

	//KUBUS BAWAH 

	mat = tilting*translationMTX(-50, -tick3c, -50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(0, -tick2c, -50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(50, -tick1c, -50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);

	mat = tilting*translationMTX(-50, -tick4c, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(0, -tick5c, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(50, -tick6c, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);

	mat = tilting*translationMTX(-50, -tick9c, 50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(0, -tick8c, 50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);
	mat = tilting*translationMTX(50, -tick7c, 50)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, hijau, mat);

	//========================================================

	//KUBUS TENGAH

	mat = tilting*translationMTX(-50, 0, -tick7b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(0, 0, -tick8b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(50, 0, -tick9b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);

	mat = tilting*translationMTX(-tick6b, 0, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(0, tick5b / 50, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(tick4b, 0, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);


	mat = tilting*translationMTX(-50, 0, tick1b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(0, 0, tick2b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);
	mat = tilting*translationMTX(50, 0, tick3b)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, kuning, mat);




	//==========================================================

	//KUBUS ATAS

	mat = tilting*translationMTX(-50, 50, -tick3a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(0, 50, -tick2a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(50, 50, -tick1a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);

	mat = tilting*translationMTX(-50, tick4a, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(0, tick5a, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(50, tick6a, 0)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);

	mat = tilting*translationMTX(-50, 50, tick9a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(0, 50, tick8a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);
	mat = tilting*translationMTX(50, 50, tick7a)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, merah, mat);







	//===========================================================


	tick1a += 1;
	if (tick1a>300)
		tick2a += 1;
	if (tick2a>300)
		tick3a += 1;
	if (tick3a>300)
		tick4a += 1;
	if (tick4a>300)
		tick5a += 1;
	if (tick5a>300)
		tick6a += 1;
	if (tick6a>300)
		tick7a += 1;
	if (tick7a>300)
		tick8a += 1;
	if (tick8a>300)
		tick9a += 1;


	if (tick9a>300)
		tick1b += 1;
	if (tick1b>300)
		tick2b += 1;
	if (tick2b>300)
		tick3b += 1;
	if (tick3b>300)
		tick4b += 1;
	if (tick4b>300)
		tick5b += 50;
	if (tick4b>400)
		tick6b += 1;
	if (tick6b>300)
		tick7b += 1;
	if (tick7b>300)
		tick8b += 1;
	if (tick8b>300)
		tick9b += 1;

	if (tick9b>300)
		tick1c += 1;
	if (tick1c>300)
		tick2c += 1;
	if (tick2c>300)
		tick3c += 1;
	if (tick3c>300)
		tick4c += 1;
	if (tick4c>300)
		tick5c += 1;
	if (tick5c>300)
		tick6c += 1;
	if (tick6c>300)
		tick7c += 1;
	if (tick7c>300)
		tick8c += 1;
	if (tick8c>300)
		tick9c += 1;




	/*
	if(tick1>200 || tick1<50) dtick=-dtick;
	tick1+=dtick;
	timeTick++;
	if(timeTick>200) timeTick=0;
	*/



}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT);
	userdraw();
	glutSwapBuffers();
}

int main(int argc, char ** argv) {
	// insert code here...
	glutInit(&argc, argv); //inisialisasi toolkit
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(640, 480);
	glutCreateWindow("Komposisi Transformasi Kubus 3");
	glClearColor(0.0, 0.0, 0.0, 0.0);
	gluOrtho2D(-320, 320, -240, 240);
	glutIdleFunc(display);
	glutDisplayFunc(display);
	glutMainLoop();
	return 0;
}