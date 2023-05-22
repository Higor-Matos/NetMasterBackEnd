Ù
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Infrastructure\NetMaster.Infrastructure\Context\MongoDbContext.cs
	namespace 	
	NetMaster
 
. 
Infrastructure "
." #
Context# *
{ 
public 

class 
MongoDbContext 
:  !
IMongoDbContext" 1
{ 
public 
MongoDbContext 
( 
string $
connectionString% 5
,5 6
string7 =
databaseName> J
)J K
{		 	
MongoClient

 
client

 
=

  
new

! $
MongoClient

% 0
(

0 1
connectionString

1 A
)

A B
;

B C
Database 
= 
client 
. 
GetDatabase )
() *
databaseName* 6
)6 7
;7 8
} 	
public 
IMongoDatabase 
Database &
{' (
get) ,
;, -
}. /
} 
} î
€C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Infrastructure\NetMaster.Infrastructure\Interface\IMongoDbContext.cs
	namespace 	
	NetMaster
 
. 
Infrastructure "
." #
Context# *
{ 
public 

	interface 
IMongoDbContext $
{ 
IMongoDatabase 
Database 
{  !
get" %
;% &
}' (
}		 
}

 â
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Infrastructure\NetMaster.Infrastructure\Upload\FileUtils.cs
	namespace 	
	NetMaster
 
. 
Infrastructure "
." #
Utils# (
{ 
public 

static 
class 
	FileUtils !
{ 
public		 
static		 
byte		 
[		 
]		 
ReadFileData		 )
(		) *
	IFormFile		* 3
file		4 8
)		8 9
{

 	
using 
MemoryStream 
memoryStream +
=, -
new. 1
(1 2
)2 3
;3 4
file 
. 
CopyTo 
( 
memoryStream $
)$ %
;% &
return 
memoryStream 
.  
ToArray  '
(' (
)( )
;) *
} 	
} 
} 