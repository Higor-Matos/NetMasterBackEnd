ƒ
kC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Configurations\MongoDbSettings.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Configuration (
{ 
public 

class 
MongoDbSettings  
{ 
public 
string 
? 
ConnectionString '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
DatabaseName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} Ù
lC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Extensions\ControllerExtensions.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 

Extensions %
{ 
public 

static 
class  
ControllerExtensions ,
{		 
public

 
static

 
IActionResult

 #
ToResult

$ ,
<

, -
T

- .
>

. /
(

/ 0
this

0 4
ControllerBase

5 C

controller

D N
,

N O
ServiceResultModel

P b
<

b c
T

c d
>

d e
value

f k
)

k l
where 
T 
: 
class 
{ 	
return 
value 
. 
SuccessResult &
!=' )
null* .
? 

controller 
. 
Ok 
(  
value  %
.% &
SuccessResult& 3
.3 4
Result4 :
): ;
: 
value 
. 
ErrorResult #
!=$ &
null' +
? 

controller  
.  !

BadRequest! +
(+ ,
value, 1
.1 2
ErrorResult2 =
.= >
ErrorMessage> J
)J K
: 

controller  
.  !

StatusCode! +
(+ ,
StatusCodes, 7
.7 8(
Status500InternalServerError8 T
)T U
;U V
} 	
} 
} ü

pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\BaseInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

abstract 
class 
BaseInfoDataModel +
{ 
[		 	
BsonId			 
]		 
[

 	
BsonRepresentation

	 
(

 
BsonType

 $
.

$ %
ObjectId

% -
)

- .
]

. /
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
	IpAddress  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	
BsonDateTimeOptions	 
( 
Kind !
=" #
DateTimeKind$ 0
.0 1
Utc1 4
)4 5
]5 6
public 
DateTime 
? 
	Timestamp "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ˆ
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\ChocolateyInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class #
ChocolateyInfoDataModel (
:) *
BaseInfoDataModel+ <
{ 
[ 	
BsonElement	 
( 
$str (
)( )
]) *
public 
string 
? 
ChocolateyVersion (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
[		 	
BsonElement			 
(		 
$str		 %
)		% &
]		& '
public

 
string

 
?

 
PSComputerName

 %
{

& '
get

( +
;

+ ,
set

- 0
;

0 1
}

2 3
} 
} ¬

|C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\InstalledProgramInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class *
InstalledProgramsResponseModel /
:0 1
BaseInfoDataModel2 C
{ 
public 
string 
? 
PSComputerName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
List 
< )
InstalledProgramInfoDataModel 1
>1 2
?2 3
Programs4 <
{= >
get? B
;B C
setD G
;G H
}I J
} 
public		 

class		 )
InstalledProgramInfoDataModel		 .
{

 
public 
string 
? 
DisplayName "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
DisplayVersion %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} º
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\NetworkComputerDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public		 

class		 
NetworkComputer		  
{

 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
IP 
{ 
get 
; 
set  #
;# $
}% &
} 
} ∆
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\OSVersionInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class "
OSVersionInfoDataModel '
:( )
BaseInfoDataModel* ;
{ 
public 
string 
? 
Caption 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
Version 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
PSComputerName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
}		 
}

 º
oC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\RamInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class 
RamInfoDataModel !
:" #
BaseInfoDataModel$ 5
{ 
public 
double !
FreePhysicalMemory_GB +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
double %
TotalVisibleMemorySize_GB /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
string 
? 
PSComputerName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
}

 
} ‘
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\StorageInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class  
StorageInfoDataModel %
:& '
BaseInfoDataModel( 9
{ 
public 
string 
? 
DeviceID 
{  !
get" %
;% &
set' *
;* +
}, -
public 
double 
Size_GB 
{ 
get  #
;# $
set% (
;( )
}* +
public 
double 
FreeSpace_GB "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
PSComputerName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
}

 
} “
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\DataModels\UsersInfoDataModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class 
LocalUserModel 
{ 
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
public 

class 
UsersInfoDataModel #
:$ %
BaseInfoDataModel& 7
{		 
public

 
List

 
<

 
LocalUserModel

 "
>

" #
?

# $
Users

% *
{

+ ,
get

- 0
;

0 1
set

2 5
;

5 6
}

7 8
public 
string 
? 
PSComputerName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} ≈
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\RepositoryPowerShellParamModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
{ 
public 

class *
RepositoryPowerShellParamModel /
{ 
public *
RepositoryPowerShellParamModel -
(- .
string. 4
ip5 7
)7 8
{ 	
Ip 
= 
ip 
; 
} 	
public

 
string

 
Ip

 
{

 
get

 
;

 
}

  !
} 
} õ
eC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\Request\IpRequest.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "

DataModels" ,
{ 
public 

class 
	IpRequest 
{ 
public 
string 
? 
Ip 
{ 
get 
;  
set! $
;$ %
}& '
} 
}		 ·
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\Request\SoftwareInstallRequest.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "
Request" )
{ 
public 

class "
SoftwareInstallRequest '
{ 
public 
string 
? 
Ip 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
SoftwareName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
}		 Ç/
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\Results\RepositoryResultModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "
Results" )
{ 
public 

class !
RepositoryResultModel &
{ 
public 
string 
Ip 
{ 
get 
; 
set  #
;# $
}% &
public #
SuccessRepositoryResult &
?& '
SuccessResult( 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
public !
ErrorRepositoryResult $
?$ %
ErrorResult& 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
	protected

 !
RepositoryResultModel

 '
(

' (#
SuccessRepositoryResult

( ?
?

? @
success

A H
=

I J
null

K O
,

O P!
ErrorRepositoryResult

Q f
?

f g
error

h m
=

n o
null

p t
,

t u
string

v |
ip

} 
=


Ä Å
$str


Ç Ñ
)


Ñ Ö
{ 	
SuccessResult 
= 
success #
;# $
ErrorResult 
= 
error 
;  
Ip 
= 
ip 
; 
} 	
} 
public 

class !
RepositoryResultModel &
<& '
T' (
>( )
:* +!
RepositoryResultModel, A
{ 
public 
T 
Data 
{ 
get 
; 
set !
;! "
}# $
public 
bool 
Success 
{ 
get !
;! "
set$ '
;' (
}) *
public 
string 
Message 
{ 
get  #
;# $
set& )
;) *
}+ ,
public 
new #
SuccessRepositoryResult *
<* +
T+ ,
>, -
?- .
SuccessResult/ <
{ 	
get 
=> 
( #
SuccessRepositoryResult +
<+ ,
T, -
>- .
?. /
)/ 0
base0 4
.4 5
SuccessResult5 B
;B C
	protected 
set 
=> 
base !
.! "
SuccessResult" /
=0 1
value2 7
;7 8
} 	
public !
RepositoryResultModel $
($ %
T% &
data' +
=, -
default. 5
(5 6
T6 7
)7 8
,8 9
bool: >
success? F
=G H
falseI N
,N O
stringP V
messageW ^
=_ `
$stra c
,c d!
ErrorRepositoryResulte z
?z {
error	| Å
=
Ç É
null
Ñ à
,
à â
string
ä ê
ip
ë ì
=
î ï
$str
ñ ò
)
ò ô
: 
base 
( 
success 
? 
new  #
SuccessRepositoryResult! 8
<8 9
T9 :
>: ;
(; <
data< @
)@ A
:B C
nullD H
,H I
errorJ O
,O P
ipQ S
)S T
{   	
Data!! 
=!! 
data!! 
;!! 
Success"" 
="" 
success"" 
;"" 
Message## 
=## 
message## 
;## 
Ip$$ 
=$$ 
ip$$ 
;$$ 
}%% 	
public'' !
RepositoryResultModel'' $
(''$ %!
RepositoryResultModel''% :
model''; @
)''@ A
{(( 	
SuccessResult)) 
=)) 
()) #
SuccessRepositoryResult)) 4
<))4 5
T))5 6
>))6 7
?))7 8
)))8 9
model))9 >
.))> ?
SuccessResult))? L
;))L M
ErrorResult** 
=** 
model** 
.**  
ErrorResult**  +
;**+ ,
}++ 	
},, 
public.. 

class.. #
SuccessRepositoryResult.. (
{// 
}00 
public22 

class22 #
SuccessRepositoryResult22 (
<22( )
T22) *
>22* +
:22, -#
SuccessRepositoryResult22. E
{33 
public44 #
SuccessRepositoryResult44 &
(44& '
T44' (
result44) /
)44/ 0
{55 	
Result66 
=66 
result66 
;66 
}77 	
public99 
T99 
Result99 
{99 
get99 
;99 
}99  
}:: 
public<< 

class<< !
ErrorRepositoryResult<< &
{== 
public>> !
ErrorRepositoryResult>> $
(>>$ %
	Exception>>% .
	exception>>/ 8
,>>8 9
string>>: @
message>>A H
=>>I J
$str>>K M
)>>M N
{?? 	
	Exception@@ 
=@@ 
	exception@@ !
;@@! "
MessageAA 
=AA 
messageAA 
;AA 
}BB 	
publicDD 
	ExceptionDD 
	ExceptionDD "
{DD# $
getDD% (
;DD( )
}DD* +
publicEE 
stringEE 
MessageEE 
{EE 
getEE  #
;EE# $
setEE% (
;EE( )
}EE* +
}FF 
}GG  "
nC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\Results\ServiceResultModel.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "
Results" )
{ 
public 

class 
ServiceResultModel #
<# $
T$ %
>% &
where' ,
T- .
:/ 0
class1 6
{ 
public 
ServiceResultModel !
(! " 
SuccessServiceResult  
<  !
T! "
>" #
?# $
success% ,
=- .
null/ 3
,3 4
ErrorServiceResult 
? 
error  %
=& '
null( ,
)		 	
{

 	
SuccessResult 
= 
success #
;# $
ErrorResult 
= 
error 
;  
} 	
public  
SuccessServiceResult #
<# $
T$ %
>% &
?& '
SuccessResult( 5
{6 7
get8 ;
;; <
}= >
public 
ErrorServiceResult !
?! "
ErrorResult# .
{/ 0
get1 4
;4 5
}6 7
public 
bool 
	IsSuccess 
=>  
SuccessResult! .
!=/ 1
null2 6
;6 7
public 
T 
? 
Success 
=> 
SuccessResult *
?* +
.+ ,
Result, 2
;2 3
public 
string 
? 
Error 
=> 
ErrorResult  +
?+ ,
., -
ErrorMessage- 9
;9 :
} 
public 

class  
SuccessServiceResult %
{ 
public 
DateTime 
	Timestamp !
{" #
get$ '
;' (
}) *
public 
string 
ComputerName "
{# $
get% (
;( )
}* +
	protected  
SuccessServiceResult &
(& '
DateTime' /
	timestamp0 9
,9 :
string; A
computerNameB N
)N O
{ 	
	Timestamp 
= 
	timestamp !
;! "
ComputerName 
= 
computerName '
;' (
} 	
}   
public"" 

class""  
SuccessServiceResult"" %
<""% &
T""& '
>""' (
:"") * 
SuccessServiceResult""+ ?
{## 
public$$  
SuccessServiceResult$$ #
($$# $
T$$$ %
result$$& ,
,$$, -
DateTime$$. 6
	timestamp$$7 @
,$$@ A
string$$B H
computerName$$I U
)$$U V
:$$W X
base$$Y ]
($$] ^
	timestamp$$^ g
,$$g h
computerName$$i u
)$$u v
{%% 	
Result&& 
=&& 
result&& 
;&& 
}'' 	
public)) 
T)) 
Result)) 
{)) 
get)) 
;)) 
}))  
}** 
public,, 

class,, 
ErrorServiceResult,, #
{-- 
public.. 
ErrorServiceResult.. !
(..! "
string.." (
errorMessage..) 5
,..5 6
DateTime..7 ?
	timestamp..@ I
,..I J
string..K Q
computerName..R ^
)..^ _
{// 	
ErrorMessage00 
=00 
errorMessage00 '
;00' (
	Timestamp11 
=11 
	timestamp11 !
;11! "
ComputerName22 
=22 
computerName22 '
;22' (
}33 	
public55 
string55 
ErrorMessage55 "
{55# $
get55% (
;55( )
}55* +
public66 
DateTime66 
	Timestamp66 !
{66" #
get66$ '
;66' (
}66) *
public77 
string77 
ComputerName77 "
{77# $
get77% (
;77( )
}77* +
}88 
}99 ∞
hC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Domain.csproj\Models\Results\UploadResult.cs
	namespace 	
	NetMaster
 
. 
Domain 
. 
Models !
.! "
Results" )
{ 
public		 

class		 
UploadResult		 
{

 
public 
string 
FilePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} 