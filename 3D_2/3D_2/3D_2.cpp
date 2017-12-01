// kubus.cpp : Defines the entry point for the console application.
//#include <stdafx.h>
#include <math.h>
#include <glut.h>
#define HALFAXIS  220
#define HALFAXIS1 (HALFAXIS-10)


typedef struct {
	float m[4][4];
} matrix3D_t;

typedef struct {
	float v[4];
} vector3D_t;

typedef struct {
	float x;
	float y;
	float z;
} point3D_t;

typedef struct {
	float x;
	float y;
} point2D_t;

typedef struct {
	float r;
	float g;
	float b;
} color_t;

////////////////// matrices and vectors 3D ver 2 /////////////////
matrix3D_t createIdentity(void)
{
	matrix3D_t u;
	int i, j;
	for (i = 0; i<4; i++) {
		for (j = 0; j<4; j++) u.m[i][j] = 0.;
		u.m[i][i] = 1.;
	}
	return u;
}

matrix3D_t operator * (matrix3D_t a, matrix3D_t b)
{
	matrix3D_t c;//c=a*b
	int i, j, k;
	for (i = 0; i<4; i++) for (j = 0; j<4; j++) {
		c.m[i][j] = 0;
		for (k = 0; k<4; k++) c.m[i][j] += a.m[i][k] * b.m[k][j];
	}
	return c;
}

vector3D_t operator * (matrix3D_t a, vector3D_t b)
{
	vector3D_t c;//c=a*b
	int i, j;
	for (i = 0; i<4; i++) {
		c.v[i] = 0;
		for (j = 0; j<4; j++) c.v[i] += a.m[i][j] * b.v[j];
	}
	return c;
}

matrix3D_t translationMTX(float dx, float dy, float dz)
{
	matrix3D_t trans = createIdentity();
	trans.m[0][3] = dx;
	trans.m[1][3] = dy;
	trans.m[2][3] = dz;
	return trans;
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

matrix3D_t rotationYMTX(float theta)
{
	matrix3D_t rotate = createIdentity();
	float cs = cos(theta);
	float sn = sin(theta);
	rotate.m[0][0] = cs; rotate.m[0][2] = sn;
	rotate.m[2][0] = -sn; rotate.m[2][2] = cs;
	return rotate;
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

matrix3D_t scalingMTX(float factorx, float factory, float factorz)
{
	matrix3D_t scale = createIdentity();
	scale.m[0][0] = factorx;
	scale.m[1][1] = factory;
	scale.m[2][2] = factorz;
	return scale;
}

matrix3D_t perspectiveMTX(float eyelength)
{
	matrix3D_t perspective = createIdentity();
	perspective.m[3][2] = -1. / eyelength;
	return perspective;
}

point2D_t Vector2Point2D(vector3D_t vec)
{
	point2D_t pnt;
	pnt.x = vec.v[0];
	pnt.y = vec.v[1];
	return pnt;
}

point3D_t Vector2Point3D(vector3D_t vec)
{
	point3D_t pnt;
	pnt.x = vec.v[0];
	pnt.y = vec.v[1];
	pnt.z = vec.v[2];
	return pnt;
}

vector3D_t Point2Vector(point3D_t pnt)
{
	vector3D_t vec;
	vec.v[0] = pnt.x;
	vec.v[1] = pnt.y;
	vec.v[2] = pnt.z;
	vec.v[3] = 1.;
	return vec;
}

vector3D_t homogenizeVector(vector3D_t vec)
{
	int i;
	for (i = 0; i<3; i++) {
		vec.v[i] /= vec.v[3];
	}
	vec.v[3] = 1.;
	return vec;
}

vector3D_t unitVector(vector3D_t vec)
{
	int i;
	float vec2 = 0.;
	float vec1, invvec1;
	for (i = 0; i<3; i++) {
		vec2 += vec.v[i] * vec.v[i];
	}
	vec1 = sqrt(vec2);
	if (vec1 != 0.) {
		invvec1 = 1. / vec1;
		for (i = 0; i<3; i++) {
			vec.v[i] *= invvec1;
		}
	}
	vec.v[3] = 1.;
	return vec;
}

// inner product (dot product) of homogeneous vector
float operator * (vector3D_t a, vector3D_t b)
{
	float c;//c=a*b
	int i;
	c = 0;
	for (i = 0; i<3; i++) {
		c += a.v[i] * b.v[i];
	}
	return c;
}

// outer product (cross product ) of homogeneous vector
//       i         j         k
//       a0       a1        a2
//       b0       b1        b2
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

vector3D_t operator * (float r, vector3D_t b)
{
	vector3D_t c;//c=r*b
	int i;
	for (i = 0; i<3; i++) {
		c.v[i] = r*b.v[i];
	}
	c.v[3] = 1.;
	return c;
}

vector3D_t operator * (vector3D_t b, float r)
{
	vector3D_t c;//c=r*b
	int i;
	for (i = 0; i<3; i++) {
		c.v[i] = r*b.v[i];
	}
	c.v[3] = 1.;
	return c;
}

float funcPositive(float x)
{
	if (0.<x) return x;
	else return 0.;
}

// x to yth power
float power(float x, float y)
{
	//ln z = y ln x        z = exp (y ln x)
	if (x == 0.) return 0;
	return exp(y*log(x));
}

color_t operator + (color_t c1, color_t c2)
{
	color_t col;
	col.r = c1.r + c2.r;
	col.g = c1.g + c2.g;
	col.b = c1.b + c2.b;
	return col;
}

color_t operator * (float r, color_t c)
{
	color_t col;
	col.r = r*c.r;
	col.g = r*c.g;
	col.b = r*c.b;
	return col;
}

color_t operator * (color_t c, float r)
{
	color_t col;
	col.r = r*c.r;
	col.g = r*c.g;
	col.b = r*c.b;
	return col;
}


// LightVector, NormalVector, ViewVector, ColorofObject
color_t PhongModel(vector3D_t Light, vector3D_t Normal, vector3D_t View, color_t col)
{
	float kspe = 0.7; // specular reflection coefficient
	float kdif = 0.6; // diffuse reflection coefficient
	float kamb = 0.4; // ambient light coefficient
	float tmp, NL, RV;
	color_t ColWhite = { 1,1,1 };
	vector3D_t ReflectionVector = (2.*(Light*Normal)*Normal) - Light;
	tmp = Normal*Light;
	NL = funcPositive(tmp);
	tmp = ReflectionVector*View;
	RV = funcPositive(tmp);
	return kdif*NL*col + kspe*power(RV, 4)*ColWhite + kamb*col;
}

////////////// End of matrices and vectors 3D ver 2 //////////////

////////////// OpenGL drawShape Functions ver 1 /////////////////
void setColor(float red, float green, float blue)
{
	glColor3f(red, green, blue);
}

void setColor(color_t col)
{
	glColor3f(col.r, col.g, col.b);
}

void drawDot(float x, float y)
{
	glBegin(GL_POINTS);
	glVertex2f(x, y);
	glEnd();
}

void drawLine(float x1, float y1, float x2, float y2)
{
	glBegin(GL_LINES);
	glVertex2f(x1, y1);
	glVertex2f(x2, y2);
	glEnd();
}

void drawLine(point2D_t p1, point2D_t p2)
{
	drawLine(p1.x, p1.y, p2.x, p2.y);
}

//n: number of points
void drawPolyline(point2D_t pnt[], int n)
{
	int i;
	glBegin(GL_LINE_STRIP);
	for (i = 0; i<n; i++) {
		glVertex2f(pnt[i].x, pnt[i].y);
	}
	glEnd();
}

//n: number of vertices
void drawPolygon(point2D_t pnt[], int n)
{
	int i;
	glBegin(GL_LINE_LOOP);
	for (i = 0; i<n; i++) {
		glVertex2f(pnt[i].x, pnt[i].y);
	}
	glEnd();
}

// The function fillPolygon can fills only convex polygons
//n: number of vertices
void fillPolygon(point2D_t pnt[], int n, color_t color)
{
	int i;
	setColor(color);
	glBegin(GL_POLYGON);
	for (i = 0; i<n; i++) {
		glVertex2f(pnt[i].x, pnt[i].y);
	}
	glEnd();
}

// The function gradatePolygon can fills only convex polygons
// The vertices will be painted with corresponding given colors.
// The points inside the polygon will be painted with the mixed color.
//n: number of vertices
void gradatePolygon(point2D_t pnt[], color_t col[], int num)
{
	int i;
	glBegin(GL_POLYGON);
	for (i = 0; i<num; i++) {
		setColor(col[i]);
		glVertex2f(pnt[i].x, pnt[i].y);
	}
	glEnd();
}

//////////// End of OpenGL drawShape Functions ver 1 ////////////

void userdraw(void);

void display(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	userdraw();
	glutSwapBuffers();
}

//////////////////////////////////////////////////////////////////
void drawcharX(float x, float y)
{
	drawLine(x, y, x + 10, y + 12); drawLine(x, y + 12, x + 10, y);
}

void drawcharY(float x, float y)
{
	drawLine(x + 5, y, x + 5, y + 7); drawLine(x, y + 12, x + 5, y + 7); drawLine(x + 10, y + 12, x + 5, y + 7);
}

void drawcharZ(float x, float y)
{
	drawLine(x, y + 12, x + 10, y + 12); drawLine(x + 10, y + 12, x, y); drawLine(x, y, x + 10, y);
}

void drawAxes(matrix3D_t view)
{
	point3D_t axes[14] = {
		{ -HALFAXIS,0,0 },{ HALFAXIS,0,0 },{ HALFAXIS1,5,0 },{ HALFAXIS1,0,0 },{ 0,0,0 },
		{ 0,-HALFAXIS,0 },{ 0,HALFAXIS,0 },{ 0,HALFAXIS1,5 },{ 0,HALFAXIS1,0 },{ 0,0,0 },
		{ 0,0,-HALFAXIS },{ 0,0,HALFAXIS },{ 5,0,HALFAXIS1 },{ 0,0,HALFAXIS1 }
	};
	vector3D_t vec[14];
	point2D_t buff[14];
	int i;
	for (i = 0; i<14; i++) {
		vec[i] = Point2Vector(axes[i]);
		vec[i] = view*vec[i];
		buff[i] = Vector2Point2D(vec[i]);
	}
	drawPolyline(buff, 14);
	drawcharX(buff[1].x, buff[1].y);
	drawcharY(buff[6].x, buff[6].y);
	drawcharZ(buff[11].x - 14, buff[11].y);
}

//////////////////////////////////////////////////////////////////
typedef struct {
	int NumberofVertices; //in the face
	short int pnt[32];
} face_t;

typedef struct {
	int NumberofVertices; //of the object
	point3D_t pnt[200];
	int NumberofFaces; //of the object
	face_t fc[100];
} object3D_t;


void draw3D(object3D_t obyek, matrix3D_t mat)
{
	vector3D_t vec[1000], vecbuff[360], NormalVector;
	float normalzi;
	point2D_t titik2D[360];
	int i, j;
	// Transformasi terhadap semua titik
	for (i = 0; i<obyek.NumberofVertices; i++) {
		vec[i] = Point2Vector(obyek.pnt[i]);
		vec[i] = mat*vec[i];
	}


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
				titik2D[j] = Vector2Point2D(vec[obyek.fc[i].pnt[j]]);
			drawPolygon(titik2D, obyek.fc[i].NumberofVertices);
		}
	}
	//face visible
	setColor(0, 1, 1);
	for (i = 0; i<obyek.NumberofFaces; i++) {
		for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
			vecbuff[j] = vec[obyek.fc[i].pnt[j]];
		NormalVector = (vecbuff[1] - vecbuff[0]) ^ (vecbuff[2] - vecbuff[0]);
		normalzi = NormalVector.v[2];
		if (normalzi>0.)
		{
			for (j = 0; j<obyek.fc[i].NumberofVertices; j++)
				titik2D[j] = Vector2Point2D(vec[obyek.fc[i].pnt[j]]);
			drawPolygon(titik2D, obyek.fc[i].NumberofVertices);
		}
	}

}



void userdraw(void)
{
	static float tick = 0, stick = 0.001, tick1 = 0.4, tick2 = -0.5;
	matrix3D_t tilting = rotationXMTX(0.5)*rotationYMTX(0.5);
	matrix3D_t tilting1 = rotationXMTX(0.25)*rotationYMTX(0.5);
	setColor(0, 1, 0);
	//	drawAxes(tilting);

	object3D_t kubus = { 8,
	{ { 100,100,100 },{ 100,100,-100 },{ -100,100,-100 },{ -100,100,100 },{ 100,-100,100 },{ 100,-100,-100 },{ -100,-100,-100 },{ -100,-100,100 } },
		6,
		{ { 4,{ 0,3,7,4 } },{ 4,{ 1,5,6,2 } },{ 4,{ 0,4,5,1 } },{ 4,{ 2,6,7,3 } },{ 4,{ 0,1,2,3 } },{ 4,{ 4,7,6,5 } } } };



	matrix3D_t mat;
	mat = tilting*rotationYMTX(15 * tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat);

	mat = tilting*translationMTX(0, 120 * tick, 0)*rotationYMTX(15 * tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat); //atas
	mat = tilting*translationMTX(0, -120 * tick, 0)*rotationYMTX(15 * tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat); //bawah


	mat = tilting*translationMTX(120 * tick, 0, 0)*rotationYMTX(10 * tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat); // samping belakang
	mat = tilting*translationMTX(-120 * tick, 0, 0)*rotationYMTX(10 * tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat);//samping depan

	mat = tilting*translationMTX(0, 0, 120 * tick)*rotationYMTX(tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat);  // samping kanan
	mat = tilting*translationMTX(0, 0, -120 * tick)*rotationYMTX(tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat); //samping kiri

						//++++++++++++++++++++++++++++++++++++++++++++

	mat = tilting*translationMTX(-120 * tick, 0, 120 * tick)*rotationYMTX(tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat);  // tengah bawah
	mat = tilting*translationMTX(120 * tick, 0, -120 * tick)*rotationYMTX(tick)*scalingMTX(0.5, 0.5, 0.5);
	draw3D(kubus, mat); //tengah atas

						//++++++++++++++++++++++++++++++++++++++++++++
						//++++++++++++++++++++++++++++++++++++++++++++
	setColor(1, 0, 0);
	mat = tilting1*rotationYMTX(150 * tick)*scalingMTX(0.25, 0.25, 0.25)*translationMTX(10 * tick, 0, 0);
	draw3D(kubus, mat);

	mat = tilting1*rotationYMTX(200 * tick)*scalingMTX(0.125, 2, 0.125)*translationMTX(10 * tick, 0, 0);
	draw3D(kubus, mat);

	mat = tilting*translationMTX(0, 120 * tick, 0)*rotationYMTX(150 * tick)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, mat); //atas
	mat = tilting*translationMTX(0, -120 * tick, 0)*rotationYMTX(150 * tick)*scalingMTX(0.25, 0.25, 0.25);
	draw3D(kubus, mat); //bawah

						/*mat=tilting*translationMTX(0,120*tick1,0)*rotationYMTX(150*tick)*scalingMTX(0.25,0.25,0.25);
						draw3D(kubus,mat); //atas
						mat=tilting*translationMTX(0,-120*tick1,0)*rotationYMTX(150*tick)*scalingMTX(0.25,0.25,0.25);
						draw3D(kubus,mat); //bawah*/

						//++++++++++++++++++++++++++++++++++++++++++++
	tick += stick;
	if (tick>2 || tick<0) stick = -stick;

}

int main(int argc, char **argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(720, 560);
	glutCreateWindow("Komposisi Transformasi Kubus 2");
	glClearColor(0.0, 0.0, 0.0, 0.0);
	gluOrtho2D(-360., 360., -280.0, 280.0);
	// Define the dimensions of the Orthographic Viewing Volume
	glutIdleFunc(display); // idle event call back
	glutDisplayFunc(display);
	glutMainLoop();
	return 0;
}


