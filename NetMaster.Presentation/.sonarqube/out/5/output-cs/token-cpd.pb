ˇ
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Configuration\StreamingServerConfigPresentation.cs
public 
class -
!StreamingServerConfigPresentation .
{ 
public 

string 
? 
FileName 
{ 
get !
;! "
set# &
;& '
}( )
public 

bool 
UseShellExecute 
{  !
get" %
;% &
set' *
;* +
}, -
public 

bool "
RedirectStandardOutput &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

bool 
CreateNoWindow 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Configuration\SwaggerConfigurationPresentation.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Configuration! .
{ 
public 

static 
class ,
 SwaggerConfigurationPresentation 8
{ 
public 
static 
void #
AddSwaggerDocumentation 2
(2 3
this3 7
IServiceCollection8 J
servicesK S
)S T
{ 	
_		 
=		 
services		 
.		 
AddSwaggerGen		 &
(		& '
c		' (
=>		) +
{

 
c 
. 

SwaggerDoc 
( 
$str !
,! "
new# &
OpenApiInfo' 2
{ 
Title 
= 
$str +
,+ ,
Version 
= 
$str "
," #
Description 
=  !
$str" T
,T U
Contact 
= 
new !
OpenApiContact" 0
{ 
Name 
= 
$str ,
,, -
Email 
= 
$str  7
,7 8
Url 
= 
new !
Uri" %
(% &
$str& F
)F G
} 
} 
) 
; 
} 
) 
; 
} 	
public 
static 
void #
UseSwaggerDocumentation 2
(2 3
this3 7
IApplicationBuilder8 K
appL O
)O P
{ 	
_ 
= 
app 
. 

UseSwagger 
( 
)  
;  !
_ 
= 
app 
. 
UseSwaggerUI  
(  !
c! "
=># %
{ 
c 
. 
SwaggerEndpoint !
(! "
$str" <
,< =
$str> P
)P Q
;Q R
c   
.   
RoutePrefix   
=   
$str    )
;  ) *
}!! 
)!! 
;!! 
}"" 	
}## 
}$$ â
fC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\BaseController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
public 

abstract 
class 
BaseController (
:) *
ControllerBase+ 9
{		 
	protected

 
IActionResult

 
ToActionResult

  .
<

. /
T

/ 0
>

0 1
(

1 2
ServiceResultModel

2 D
<

D E
T

E F
>

F G
result

H N
)

N O
where

P U
T

V W
:

X Y
class

Z _
{ 	
return 
this 
. 
ToResult  
(  !
result! '
)' (
;( )
} 	
} 
} œ
jC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\HardwareController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public		 

class		 
HardwareController		 #
:		$ %
BaseController		& 4
{

 
private 
readonly 
IHardwareService )
_hardwareService* :
;: ;
public 
HardwareController !
(! "
IHardwareService" 2
hardwareService3 B
)B C
{ 	
_hardwareService 
= 
hardwareService .
;. /
} 	
[ 	
HttpGet	 
( 
$str -
)- .
]. /
public 
async 
Task 
< 
IActionResult '
>' (

GetRamInfo) 3
(3 4
string4 :
computerName; G
)G H
{ 	
Domain 
. 
Models 
. 
Results !
.! "
ServiceResultModel" 4
<4 5
Domain5 ;
.; <
Models< B
.B C

DataModelsC M
.M N
RamInfoDataModelN ^
>^ _
result` f
=g h
awaiti n
_hardwareServiceo 
.	 Ä
GetRamInfoAsync
Ä è
(
è ê
computerName
ê ú
)
ú ù
;
ù û
return 
ToActionResult !
(! "
result" (
)( )
;) *
} 	
[ 	
HttpGet	 
( 
$str 1
)1 2
]2 3
public 
async 
Task 
< 
IActionResult '
>' (
GetStorageInfo) 7
(7 8
string8 >
computerName? K
)K L
{ 	
Domain 
. 
Models 
. 
Results !
.! "
ServiceResultModel" 4
<4 5
Domain5 ;
.; <
Models< B
.B C

DataModelsC M
.M N 
StorageInfoDataModelN b
>b c
resultd j
=k l
awaitm r
_hardwareService	s É
.
É Ñ!
GetStorageInfoAsync
Ñ ó
(
ó ò
computerName
ò §
)
§ •
;
• ¶
return 
ToActionResult !
(! "
result" (
)( )
;) *
} 	
} 
}   ª
iC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\NetworkController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
NetworkController "
:# $
BaseController% 3
{		 
private

 
readonly

 
INetworkService

 (
_networkService

) 8
;

8 9
public 
NetworkController  
(  !
INetworkService! 0
networkService1 ?
)? @
{ 	
_networkService 
= 
networkService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str '
)' (
]( )
public 
IActionResult 
ListNetworkComputer 0
(0 1
)1 2
{ 	
object 
[ 
] 
	computers 
=  
_networkService! 0
.0 1&
ListNetworkComputerCommand1 K
(K L
)L M
;M N
return 
new 

JsonResult !
(! "
new" %
{& '
success( /
=0 1
new2 5
{6 7
result8 >
=? @
newA D
{E F
	computersG P
}Q R
}S T
}U V
)V W
;W X
} 	
} 
} …
jC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\SoftwareController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
SoftwareController

 #
:

$ %
BaseController

& 4
{ 
private 
readonly 
ISoftwareService )
_softwareService* :
;: ;
public 
SoftwareController !
(! "
ISoftwareService" 2
softwareService3 B
)B C
{ 	
_softwareService 
= 
softwareService .
;. /
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
IActionResult 
InstallSoftware ,
(, -
[- .
FromBody. 6
]6 7"
SoftwareInstallRequest8 N
requestO V
)V W
{ 	
_softwareService 
. 
InstallSoftware ,
(, -
request- 4
.4 5
Ip5 7
,7 8
request9 @
.@ A
SoftwareNameA M
)M N
;N O
return 
Ok 
( 
) 
; 
} 	
} 
} ˜&
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\StreamingServerController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public		 

class		 %
StreamingServerController		 *
:		+ ,
ControllerBase		- ;
{

 
private 
readonly -
!StreamingServerConfigPresentation :
_config; B
;B C
private 
Process #
_streamingServerProcess /
;/ 0
private 
const 
string 
ProcessName (
=) *
$str+ B
;B C
public %
StreamingServerController (
(( )
IOptions) 1
<1 2-
!StreamingServerConfigPresentation2 S
>S T
configU [
,[ \$
IHostApplicationLifetime] u
appLifetime	v Å
)
Å Ç
{ 	
_config 
= 
config 
. 
Value "
;" #
_ 
= 
appLifetime 
. 
ApplicationStopping /
./ 0
Register0 8
(8 9!
OnApplicationStopping9 N
)N O
;O P
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
IActionResult !
ToggleStreamingServer 2
(2 3
)3 4
{ 	
try 
{ 
if 
( 
IsServerRunning #
(# $
)$ %
)% &
{ 
StopStreamingServer '
(' (
)( )
;) *
return 
Ok 
( 
$str 9
)9 :
;: ;
} 
else 
{  
StartStreamingServer   (
(  ( )
)  ) *
;  * +
return!! 
Ok!! 
(!! 
$str!! 9
)!!9 :
;!!: ;
}"" 
}## 
catch$$ 
($$ 
	Exception$$ 
ex$$ 
)$$  
{%% 
return&& 

StatusCode&& !
(&&! "
$num&&" %
,&&% &
$"&&' )
$str&&) <
{&&< =
ex&&= ?
.&&? @
Message&&@ G
}&&G H
"&&H I
)&&I J
;&&J K
}'' 
}(( 	
private)) 
bool)) 
IsServerRunning)) $
())$ %
)))% &
{** 	
return++ 
Process++ 
.++ 
GetProcessesByName++ -
(++- .
ProcessName++. 9
)++9 :
.++: ;
Any++; >
(++> ?
)++? @
;++@ A
},, 	
private.. 
void..  
StartStreamingServer.. )
(..) *
)..* +
{// 	
ProcessStartInfo00 
processStartInfo00 -
=00. /
new000 3
(003 4
)004 5
{11 
FileName22 
=22 
_config22 "
.22" #
FileName22# +
,22+ ,
UseShellExecute33 
=33  !
_config33" )
.33) *
UseShellExecute33* 9
,339 :"
RedirectStandardOutput44 &
=44' (
_config44) 0
.440 1"
RedirectStandardOutput441 G
,44G H
CreateNoWindow55 
=55  
_config55! (
.55( )
CreateNoWindow55) 7
}66 
;66 #
_streamingServerProcess88 #
=88$ %
new88& )
Process88* 1
{882 3
	StartInfo884 =
=88> ?
processStartInfo88@ P
}88Q R
;88R S
_99 
=99 #
_streamingServerProcess99 '
.99' (
Start99( -
(99- .
)99. /
;99/ 0
}:: 	
private;; 
void;; 
StopStreamingServer;; (
(;;( )
);;) *
{<< 	
Process== 
?== 
process== 
=== 
Process== &
.==& '
GetProcessesByName==' 9
(==9 :
ProcessName==: E
)==E F
.==F G
FirstOrDefault==G U
(==U V
)==V W
;==W X
process>> 
?>> 
.>> 
Kill>> 
(>> 
)>> 
;>> 
}?? 	
private@@ 
void@@ !
OnApplicationStopping@@ *
(@@* +
)@@+ ,
{AA 	
StopStreamingServerBB 
(BB  
)BB  !
;BB! "
}CC 	
}DD 
}EE ¥.
hC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\SystemController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
SystemController

 !
:

" #
BaseController

$ 2
{ 
private 
readonly 
ISystemService '
_systemService( 6
;6 7
private 
readonly !
ISystemCommandService .!
_systemCommandService/ D
;D E
public 
SystemController 
(  
ISystemService  .
systemService/ <
,< =!
ISystemCommandService> S 
systemCommandServiceT h
)h i
{ 	
_systemService 
= 
systemService *
;* +!
_systemCommandService !
=" # 
systemCommandService$ 8
;8 9
} 	
[ 	
HttpPost	 
( 
$str 
) 
]  
public 
async 
Task 
< 
IActionResult '
>' (

ShutdownPc) 3
(3 4
[4 5
FromBody5 =
]= >
	IpRequest? H
requestI P
)P Q
{ 	
ServiceResultModel 
< 
string %
>% &
result' -
=. /
await0 5!
_systemCommandService6 K
.K L
ShutdownPcCommandL ]
(] ^
request^ e
.e f
Ipf h
)h i
;i j
return 
ToActionResult !
(! "
result" (
)( )
;) *
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
	RestartPc) 2
(2 3
[3 4
FromBody4 <
]< =
	IpRequest> G
requestH O
)O P
{ 	
ServiceResultModel 
< 
string %
>% &
result' -
=. /
await0 5!
_systemCommandService6 K
.K L
RestartPcCommandL \
(\ ]
request] d
.d e
Ipe g
)g h
;h i
return   
ToActionResult   !
(  ! "
result  " (
)  ( )
;  ) *
}!! 	
[## 	
HttpGet##	 
(## 
$str## .
)##. /
]##/ 0
public$$ 
async$$ 
Task$$ 
<$$ 
IActionResult$$ '
>$$' (
GetUsersInfo$$) 5
($$5 6
string$$6 <
computerName$$= I
)$$I J
{%% 	
ServiceResultModel&& 
<&& 
UsersInfoDataModel&& 1
>&&1 2
result&&3 9
=&&: ;
await&&< A
_systemService&&B P
.&&P Q
GetUsersInfoAsync&&Q b
(&&b c
computerName&&c o
)&&o p
;&&p q
return'' 
ToActionResult'' !
(''! "
result''" (
)''( )
;'') *
}(( 	
[** 	
HttpGet**	 
(** 
$str** 3
)**3 4
]**4 5
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
GetChocolateyInfo++) :
(++: ;
string++; A
computerName++B N
)++N O
{,, 	
ServiceResultModel-- 
<-- #
ChocolateyInfoDataModel-- 6
>--6 7
result--8 >
=--? @
await--A F
_systemService--G U
.--U V"
GetChocolateyInfoAsync--V l
(--l m
computerName--m y
)--y z
;--z {
return.. 
ToActionResult.. !
(..! "
result.." (
)..( )
;..) *
}// 	
[11 	
HttpGet11	 
(11 
$str11 2
)112 3
]113 4
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
GetOsVersionInfo22) 9
(229 :
string22: @
computerName22A M
)22M N
{33 	
ServiceResultModel44 
<44 "
OSVersionInfoDataModel44 5
>445 6
result447 =
=44> ?
await44@ E
_systemService44F T
.44T U!
GetOsVersionInfoAsync44U j
(44j k
computerName44k w
)44w x
;44x y
return55 
ToActionResult55 !
(55! "
result55" (
)55( )
;55) *
}66 	
[88 	
HttpGet88	 
(88 
$str88 :
)88: ;
]88; <
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' ($
GetInstalledProgramsInfo99) A
(99A B
string99B H
computerName99I U
)99U V
{:: 	
ServiceResultModel;; 
<;; *
InstalledProgramsResponseModel;; =
>;;= >
result;;? E
=;;F G
await;;H M
_systemService;;N \
.;;\ ])
GetInstalledProgramsInfoAsync;;] z
(;;z {
computerName	;;{ á
)
;;á à
;
;;à â
return<< 
ToActionResult<< !
(<<! "
result<<" (
)<<( )
;<<) *
}== 	
}>> 
}?? ∞
hC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Controllers\UploadController.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !
Controllers! ,
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
UploadController

 !
:

" #
BaseController

$ 2
{ 
private 
readonly 
IUploadService '
_uploadService( 6
;6 7
public 
UploadController 
(  
IUploadService  .
uploadService/ <
)< =
{ 	
_uploadService 
= 
uploadService *
;* +
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
IActionResult 

UploadFile '
(' (
	IFormFile( 1
file2 6
)6 7
{ 	
ServiceResultModel 
< 
object %
>% &
validationResult' 7
=8 9
_uploadService: H
.H I
ValidateFileI U
(U V
fileV Z
)Z [
;[ \
if 
( 
! 
validationResult !
.! "
	IsSuccess" +
)+ ,
{ 
return 
ToActionResult %
(% &
validationResult& 6
)6 7
;7 8
} 
ServiceResultModel 
< 
UploadResult +
>+ ,
result- 3
=4 5
_uploadService6 D
.D E

UploadFileE O
(O P
fileP T
)T U
;U V
return 
ToActionResult !
(! "
result" (
)( )
;) *
} 	
} 
}   ô
kC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Extensions\ControllerExtensions.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !

Extensions! +
{ 
public 

static 
class  
ControllerExtensions ,
{ 
public		 
static		 
IActionResult		 #/
#CreateActionResultFromServiceResult		$ G
<		G H
T		H I
>		I J
(		J K
this		K O
ControllerBase		P ^

controller		_ i
,		i j
ServiceResultModel		k }
<		} ~
T		~ 
>			 Ä
value
		Å Ü
)
		Ü á
where

 
T

 
:

 
class

 
{ 	
return 
value 
. 
SuccessResult &
!=' )
null* .
? 

controller 
. 
Ok 
(  
value  %
.% &
SuccessResult& 3
.3 4
Result4 :
): ;
: 
value 
. 
ErrorResult #
!=$ &
null' +
? 

controller  
.  !

BadRequest! +
(+ ,
value, 1
.1 2
ErrorResult2 =
.= >
ErrorMessage> J
)J K
: 

controller  
.  !

StatusCode! +
(+ ,
StatusCodes, 7
.7 8(
Status500InternalServerError8 T
)T U
;U V
} 	
} 
} ¿\
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Extensions\ServiceCollectionExtensions.cs
	namespace 	
	NetMaster
 
. 
Presentation  
.  !

Extensions! +
{ 
public		 

static		 
class		 '
ServiceCollectionExtensions		 3
{

 
public 
static 
IServiceCollection (!
AddServicesInAssembly) >
(> ?
this? C
IServiceCollectionD V
servicesW _
)_ `
{ 	
IEnumerable 
< 
Assembly  
>  !

assemblies" ,
=- .
GetAssembliesToScan/ B
(B C
)C D
;D E
RegisterServices 
( 
services %
,% &

assemblies' 1
)1 2
;2 3
return 
services 
; 
} 	
private 
static 
IEnumerable "
<" #
Assembly# +
>+ ,
GetAssembliesToScan- @
(@ A
)A B
{ 	
Assembly 
entryAssembly "
=# $
Assembly% -
.- .
GetEntryAssembly. >
(> ?
)? @
;@ A
IEnumerable 
< 
Assembly  
>  !

assemblies" ,
=- .
entryAssembly/ <
.< =#
GetReferencedAssemblies= T
(T U
)U V
. 
Select 
( 
Assembly  
.  !
Load! %
)% &
. 
Concat 
( 
new 
[ 
] 
{ 
entryAssembly  -
}. /
)/ 0
;0 1
Assembly 
repositoryAssembly '
=( )
Assembly* 2
.2 3
Load3 7
(7 8
$str8 N
)N O
;O P

assemblies 
= 

assemblies #
.# $
Concat$ *
(* +
new+ .
[. /
]/ 0
{1 2
repositoryAssembly3 E
}F G
)G H
;H I
return 

assemblies 
; 
} 	
private   
static   
void   
RegisterServices   ,
(  , -
IServiceCollection  - ?
services  @ H
,  H I
IEnumerable  J U
<  U V
Assembly  V ^
>  ^ _

assemblies  ` j
)  j k
{!! 	
foreach"" 
("" 
Assembly"" 
assembly"" &
in""' )

assemblies""* 4
)""4 5
{## 
IEnumerable$$ 
<$$ 
Type$$  
>$$  !
types$$" '
=$$( )
assembly$$* 2
.$$2 3
ExportedTypes$$3 @
;$$@ A
foreach&& 
(&& 
Type&& 
type&& "
in&&# %
types&&& +
.&&+ ,
Where&&, 1
(&&1 2
t&&2 3
=>&&4 6
t&&7 8
.&&8 9
IsClass&&9 @
&&&&A C
!&&D E
t&&E F
.&&F G

IsAbstract&&G Q
)&&Q R
)&&R S
{'' "
RegisterServiceForType(( *
(((* +
services((+ 3
,((3 4
type((5 9
)((9 :
;((: ;
})) 
}** 
}++ 	
private-- 
static-- 
void-- "
RegisterServiceForType-- 2
(--2 3
IServiceCollection--3 E
services--F N
,--N O
Type--P T
type--U Y
)--Y Z
{.. 	
foreach// 
(// 
Type// 

@interface// $
in//% '
type//( ,
.//, -
GetInterfaces//- :
(//: ;
)//; <
)//< =
{00 
AutoDIAttribute11 
autoDiAttribute11  /
=110 1

@interface112 <
.11< =
GetCustomAttribute11= O
<11O P
AutoDIAttribute11P _
>11_ `
(11` a
)11a b
;11b c
if33 
(33 
autoDiAttribute33 #
!=33$ &
null33' +
)33+ ,
{44 
RegisterService55 #
(55# $
services55$ ,
,55, -
type55. 2
,552 3

@interface554 >
)55> ?
;55? @
}66 
}77 
}88 	
private:: 
static:: 
void:: 
RegisterService:: +
(::+ ,
IServiceCollection::, >
services::? G
,::G H
Type::I M
type::N R
,::R S
Type::T X

@interface::Y c
)::c d
{;; 	
if<< 
(<< 
typeof<< 
(<< 
IHostedService<< %
)<<% &
.<<& '
IsAssignableFrom<<' 7
(<<7 8
type<<8 <
)<<< =
)<<= >
{== !
RegisterHostedService?? %
(??% &
services??& .
,??. /
type??0 4
)??4 5
;??5 6
}@@ 
elseAA 
ifAA 
(AA 

@interfaceAA 
.AA  
IsGenericTypeAA  -
&&AA. 0

@interfaceAA1 ;
.AA; <$
GetGenericTypeDefinitionAA< T
(AAT U
)AAU V
==AAW Y
typeofAAZ `
(AA` a 
IBaseMongoRepositoryAAa u
<AAu v
>AAv w
)AAw x
)AAx y
{BB '
RegisterBaseMongoRepositoryDD +
(DD+ ,
servicesDD, 4
,DD4 5

@interfaceDD6 @
,DD@ A
typeDDB F
)DDF G
;DDG H
}EE 
elseFF 
ifFF 
(FF 

@interfaceFF 
==FF  "
typeofFF# )
(FF) *%
ISoftwareInstallerServiceFF* C
)FFC D
)FFD E
{GG 
_II 
=II 
servicesII 
.II 
	AddScopedII &
(II& '
providerII' /
=>II0 2
{JJ 
varKK 

dictionaryKK "
=KK# $
newKK% (

DictionaryKK) 3
<KK3 4
stringKK4 :
,KK: ;%
ISoftwareInstallerServiceKK< U
>KKU V
(KKV W
)KKW X
;KKX Y

dictionaryLL 
.LL 
AddLL "
(LL" #
$strLL# 0
,LL0 1
providerLL2 :
.LL: ;
GetRequiredServiceLL; M
<LLM N(
IAdobeReaderInstallerServiceLLN j
>LLj k
(LLk l
)LLl m
)LLm n
;LLn o

dictionaryMM 
.MM 
AddMM "
(MM" #
$strMM# ,
,MM, -
providerMM. 6
.MM6 7
GetRequiredServiceMM7 I
<MMI J$
IFirefoxInstallerServiceMMJ b
>MMb c
(MMc d
)MMd e
)MMe f
;MMf g

dictionaryNN 
.NN 
AddNN "
(NN" #
$strNN# 1
,NN1 2
providerNN3 ;
.NN; <
GetRequiredServiceNN< N
<NNN O)
IGoogleChromeInstallerServiceNNO l
>NNl m
(NNm n
)NNn o
)NNo p
;NNp q

dictionaryOO 
.OO 
AddOO "
(OO" #
$strOO# .
,OO. /
providerOO0 8
.OO8 9
GetRequiredServiceOO9 K
<OOK L&
IOffice365InstallerServiceOOL f
>OOf g
(OOg h
)OOh i
)OOi j
;OOj k

dictionaryPP 
.PP 
AddPP "
(PP" #
$strPP# (
,PP( )
providerPP* 2
.PP2 3
GetRequiredServicePP3 E
<PPE F 
IVlcInstallerServicePPF Z
>PPZ [
(PP[ \
)PP\ ]
)PP] ^
;PP^ _

dictionaryQQ 
.QQ 
AddQQ "
(QQ" #
$strQQ# +
,QQ+ ,
providerQQ- 5
.QQ5 6
GetRequiredServiceQQ6 H
<QQH I#
IWinrarInstallerServiceQQI `
>QQ` a
(QQa b
)QQb c
)QQc d
;QQd e
returnRR 

dictionaryRR %
;RR% &
}SS 
)SS 
;SS 
}UU 
elseVV 
{WW 
_YY 
=YY 
servicesYY 
.YY 
	AddScopedYY &
(YY& '

@interfaceYY' 1
,YY1 2
typeYY3 7
)YY7 8
;YY8 9
}ZZ 
Console\\ 
.\\ 
	WriteLine\\ 
(\\ 
$"\\  
$str\\  +
{\\+ ,

@interface\\, 6
.\\6 7
FullName\\7 ?
}\\? @
$str\\@ F
{\\F G
type\\G K
.\\K L
FullName\\L T
}\\T U
"\\U V
)\\V W
;\\W X
}]] 	
private`` 
static`` 
void`` !
RegisterHostedService`` 1
(``1 2
IServiceCollection``2 D
services``E M
,``M N
Type``O S
serviceType``T _
)``_ `
{aa 	

MethodInfocc 
genericMethodcc $
=cc% &
typeofcc' -
(cc- .4
(ServiceCollectionHostedServiceExtensionscc. V
)ccV W
.dd 

GetMethodsdd 
(dd 
)dd 
.ee 
Whereee 
(ee 
mee 
=>ee 
mee 
.ee 
Nameee "
==ee# %
nameofee& ,
(ee, -4
(ServiceCollectionHostedServiceExtensionsee- U
.eeU V
AddHostedServiceeeV f
)eef g
&&eeh j
meek l
.eel m
IsGenericMethodeem |
)ee| }
.ff 
Firstff 
(ff 
)ff 
;ff 

MethodInfohh 
constructedMethodhh (
=hh) *
genericMethodhh+ 8
.hh8 9
MakeGenericMethodhh9 J
(hhJ K
serviceTypehhK V
)hhV W
;hhW X
_ii 
=ii 
constructedMethodii !
.ii! "
Invokeii" (
(ii( )
nullii) -
,ii- .
newii/ 2
objectii3 9
[ii9 :
]ii: ;
{ii< =
servicesii> F
}iiG H
)iiH I
;iiI J
}jj 	
privatemm 
staticmm 
voidmm '
RegisterBaseMongoRepositorymm 7
(mm7 8
IServiceCollectionmm8 J
servicesmmK S
,mmS T
TypemmU Y

@interfacemmZ d
,mmd e
Typemmf j
typemmk o
)mmo p
{nn 	
_pp 
=pp 
servicespp 
.pp 
	AddScopedpp "
(pp" #

@interfacepp# -
,pp- .
providerpp/ 7
=>pp8 :
{qq 
MongoDbContextrr 
	dbContextrr (
=rr) *
providerrr+ 3
.rr3 4
GetRequiredServicerr4 F
<rrF G
MongoDbContextrrG U
>rrU V
(rrV W
)rrW X
;rrX Y
Typess 

genericArgss 
=ss  !

@interfacess" ,
.ss, -
GetGenericArgumentsss- @
(ss@ A
)ssA B
[ssB C
$numssC D
]ssD E
;ssE F
returnuu 
	Activatoruu  
.uu  !
CreateInstanceuu! /
(uu/ 0
typeuu0 4
,uu4 5
	dbContextuu6 ?
,uu? @

genericArguuA K
.uuK L
NameuuL P
)uuP Q
;uuQ R
}vv 
)vv 
;vv 
}ww 	
}xx 
}yy é"
SC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Presentation\Startup.cs
WebApplicationBuilder		 
builder		 
=		 
WebApplication		  .
.		. /
CreateBuilder		/ <
(		< =
args		= A
)		A B
;		B C
builder 
. 
Services 
. 
	Configure 
< 
MongoDbSettings *
>* +
(+ ,
builder, 3
.3 4
Configuration4 A
.A B

GetSectionB L
(L M
$strM ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
	Configure 
< -
!StreamingServerConfigPresentation <
>< =
(= >
builder> E
.E F
ConfigurationF S
.S T

GetSectionT ^
(^ _
$str_ p
)p q
)q r
;r s
builder 
. 
Services 
. 
AddSingleton 
< 
MongoDbContext ,
>, -
(- .
provider. 6
=>7 9
{ 
IConfiguration 
configuration  
=! "
provider# +
.+ ,
GetRequiredService, >
<> ?
IConfiguration? M
>M N
(N O
)O P
;P Q
MongoDbSettings 
mongoDbSettings #
=$ %
configuration& 3
.3 4

GetSection4 >
(> ?
$str? P
)P Q
.Q R
GetR U
<U V
MongoDbSettingsV e
>e f
(f g
)g h
;h i
return 

new 
MongoDbContext 
( 
mongoDbSettings -
.- .
ConnectionString. >
,> ?
mongoDbSettings@ O
.O P
DatabaseNameP \
)\ ]
;] ^
} 
) 
; 
builder 
. 
Services 
. !
AddServicesInAssembly &
(& '
)' (
;( )
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder   
.   
Services   
.   #
AddSwaggerDocumentation   (
(  ( )
)  ) *
;  * +
builder## 
.## 
Services## 
.## 
AddCors## 
(## 
options##  
=>##! #
{$$ 
options%% 
.%% 
	AddPolicy%% 
(%% 
$str%% '
,%%' (
builder&& 
=>&& 
{'' 	
_(( 
=(( 
builder(( 
.(( 
AllowAnyOrigin(( &
(((& '
)((' (
.((( )
AllowAnyMethod(() 7
(((7 8
)((8 9
.((9 :
AllowAnyHeader((: H
(((H I
)((I J
;((J K
})) 	
)))	 

;))
 
}** 
)** 
;** 
WebApplication,, 
app,, 
=,, 
builder,, 
.,, 
Build,, "
(,," #
),,# $
;,,$ %
app// 
.// 
UseCors// 
(// 
$str// 
)// 
;// 
app22 
.22 

UseRouting22 
(22 
)22 
;22 
app55 
.55 
UseAuthorization55 
(55 
)55 
;55 
app88 
.88 #
UseSwaggerDocumentation88 
(88 
)88 
;88 
app;; 
.;; 
UseEndpoints;; 
(;; 
	endpoints;; 
=>;; 
{<< 
_== 
=== 
	endpoints== 
.== 
MapControllers==  
(==  !
)==! "
;==" #
}>> 
)>> 
;>> 
app@@ 
.@@ 
Run@@ 
(@@ 
)@@ 	
;@@	 
