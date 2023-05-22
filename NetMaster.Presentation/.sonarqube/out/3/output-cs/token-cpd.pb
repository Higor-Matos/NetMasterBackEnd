≥
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Hardware\LocalRamRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Hardware. 6
{		 
public

 

class

 
LocalRamRepository

 #
:

$ %$
BasePowershellRepository

& >
,

> ?
ILocalRamRepository

@ S
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
RamInfoDataModel0 @
>@ A
>A B
ExecCommandC N
(N O*
RepositoryPowerShellParamModelO m
paramn s
)s t
{ 	
string 
command 
= 
$str L
+M N
$str	 ì
+
î ï
$str	 É
+
Ñ Ö
$str p
;p q
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B
ConvertOutputC P
<P Q
RamInfoDataModelQ a
>a b
(b c

jsonOutputc m
,m n
paramo t
.t u
Ipu w
)w x
)x y
;y z
} 	
} 
} ∞
yC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Hardware\LocalStorageRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Hardware. 6
{		 
public

 

class

 "
LocalStorageRepository

 '
:

( )$
BasePowershellRepository

* B
,

B C#
ILocalStorageRepository

D [
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0 
StorageInfoDataModel0 D
>D E
>E F
ExecCommandG R
(R S*
RepositoryPowerShellParamModelS q
paramr w
)w x
{ 	
string 
command 
= 
$str	 Ã
;
Ã Õ
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B
ConvertOutputC P
<P Q 
StorageInfoDataModelQ e
>e f
(f g

jsonOutputg q
,q r
params x
.x y
Ipy {
){ |
)| }
;} ~
} 	
public 
async 
Task 
< !
RepositoryResultModel /
</ 0 
StorageInfoDataModel0 D
>D E
>E F
ExecCommandG R
(R S
stringS Y
ipZ \
)\ ]
{ 	*
RepositoryPowerShellParamModel *
param+ 0
=1 2
new3 6
(6 7
ip7 9
)9 :
;: ;
return 
await 
ExecCommand $
($ %
param% *
)* +
;+ ,
} 	
} 
} ª
pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Hardware\RamRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Hardware. 6
{ 
public		 

class		 
RamRepository		 
:		  
BaseMongoRepository		! 4
<		4 5
RamInfoDataModel		5 E
>		E F
,		F G
IRamRepository		H V
{

 
public 
RamRepository 
( 
MongoDbContext +
	dbContext, 5
)5 6
:7 8
base9 =
(= >
	dbContext> G
,G H
$strI R
)R S
{ 	
} 	
} 
} œ
tC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Hardware\StorageRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Hardware. 6
{ 
public		 

class		 
StorageRepository		 "
:		# $
BaseMongoRepository		% 8
<		8 9 
StorageInfoDataModel		9 M
>		M N
,		N O
IStorageRepository		P b
{

 
public 
StorageRepository  
(  !
MongoDbContext! /
	dbContext0 9
)9 :
:; <
base= A
(A B
	dbContextB K
,K L
$strM Z
)Z [
{ 	
} 	
} 
} Â0
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\MongoDB\BaseMongoRepository.cs
	namespace

 	
	NetMaster


 
.

 

Repository

 
.

 
Implementations

 .
.

. /
MongoDB

/ 6
{ 
public 

class 
BaseMongoRepository $
<$ %
T% &
>& '
:( ) 
IBaseMongoRepository* >
<> ?
T? @
>@ A
whereB G
TH I
:J K
BaseInfoDataModelL ]
{ 
	protected 
readonly 
IMongoCollection +
<+ ,
T, -
>- .
_mongoCollection/ ?
;? @
public 
BaseMongoRepository "
(" #
MongoDbContext# 1
	dbContext2 ;
,; <
string= C
collectionNameD R
)R S
{ 	
_mongoCollection 
= 
	dbContext (
.( )
Database) 1
.1 2
GetCollection2 ?
<? @
T@ A
>A B
(B C
collectionNameC Q
)Q R
;R S
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
T& '
>' (
>( )
GetAllAsync* 5
(5 6
)6 7
{ 	
return 
await 
_mongoCollection )
.) *
Find* .
(. /
_/ 0
=>1 3
true4 8
)8 9
.9 :
ToListAsync: E
(E F
)F G
;G H
} 	
public 
async 
Task 
< 
T 
> "
GetByComputerNameAsync 3
(3 4
string4 :
computerName; G
)G H
{ 	
return 
await 
_mongoCollection )
.) *
Find* .
(. /
Builders/ 7
<7 8
T8 9
>9 :
.: ;
Filter; A
.A B
EqB D
(D E
$strE U
,U V
computerNameW c
)c d
)d e
.e f
FirstOrDefaultAsyncf y
(y z
)z {
;{ |
} 	
public 
async 
Task 
InsertAsync %
(% &
T& '
entity( .
). /
{   	
await!! 
_mongoCollection!! "
.!!" #
InsertOneAsync!!# 1
(!!1 2
entity!!2 8
)!!8 9
;!!9 :
}"" 	
public$$ 
async$$ 
Task$$ 
UpdateAsync$$ %
($$% &
T$$& '
entity$$( .
)$$. /
{%% 	
FilterDefinition&& 
<&& 
T&& 
>&& 
filter&&  &
=&&' (
Builders&&) 1
<&&1 2
T&&2 3
>&&3 4
.&&4 5
Filter&&5 ;
.&&; <
Eq&&< >
(&&> ?
$str&&? D
,&&D E
entity&&F L
.&&L M
Id&&M O
)&&O P
;&&P Q
await'' 
_mongoCollection'' "
.''" #
ReplaceOneAsync''# 2
(''2 3
filter''3 9
,''9 :
entity''; A
)''A B
;''B C
}(( 	
public** 
async** 
Task** 
<** !
RepositoryResultModel** /
<**/ 0
T**0 1
>**1 2
>**2 3,
 GetMostRecentByComputerNameAsync**4 T
(**T U
string**U [
computerName**\ h
)**h i
{++ 	
T,, 
entity,, 
=,, 
await,, -
!GetMostRecentEntityByComputerName,, >
(,,> ?
computerName,,? K
),,K L
;,,L M
return.. 
new.. !
RepositoryResultModel.. ,
<.., -
T..- .
>... /
{// 
Data00 
=00 
entity00 
,00 
Success11 
=11 
entity11  
!=11! #
null11$ (
,11( )
Message22 
=22 
entity22  
!=22! #
null22$ (
?22) *
$str22+ -
:22. /
$"220 2
$str222 V
{22V W
computerName22W c
}22c d
"22d e
}33 
;33 
}44 	
private66 
async66 
Task66 
<66 
T66 
>66 -
!GetMostRecentEntityByComputerName66 ?
(66? @
string66@ F
computerName66G S
)66S T
{77 	
FilterDefinition88 
<88 
T88 
>88 
filter88  &
=88' (
Builders88) 1
<881 2
T882 3
>883 4
.884 5
Filter885 ;
.88; <
Eq88< >
(88> ?
$str88? O
,88O P
computerName88Q ]
)88] ^
;88^ _
SortDefinition99 
<99 
T99 
>99 
sort99 "
=99# $
Builders99% -
<99- .
T99. /
>99/ 0
.990 1
Sort991 5
.995 6

Descending996 @
(99@ A
x99A B
=>99C E
x99F G
.99G H
	Timestamp99H Q
)99Q R
;99R S
IAsyncCursor:: 
<:: 
T:: 
>:: 
result:: "
=::# $
await::% *
_mongoCollection::+ ;
.::; <
	FindAsync::< E
(::E F
filter::F L
,::L M
new::N Q
FindOptions::R ]
<::] ^
T::^ _
,::_ `
T::a b
>::b c
{::d e
Sort::f j
=::k l
sort::m q
}::r s
)::s t
;::t u
return<< 
await<< 
result<< 
.<<  
FirstOrDefaultAsync<<  3
(<<3 4
)<<4 5
;<<5 6
}== 	
}>> 
}?? ø
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Powershell\BasePowershellRepository.cs
	namespace

 	
	NetMaster


 
.

 

Repository

 
.

 
Implementation

 -
.

- .

Powershell

. 8
{ 
public 

abstract 
class $
BasePowershellRepository 2
:3 4%
IBasePowershellRepository5 N
{ 
private 
readonly (
CredentialProviderRepository 5
credentialProvider6 H
;H I
	protected $
BasePowershellRepository *
(* +
)+ ,
{ 	
credentialProvider 
=  
new! $(
CredentialProviderRepository% A
(A B
)B C
;C D
} 	
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
T0 1
>1 2
>2 3
ExecCommand4 ?
<? @
T@ A
>A B
(B C*
RepositoryPowerShellParamModelC a
paramb g
,g h
stringi o
commandp w
,w x
Funcy }
<} ~
string	~ Ñ
,
Ñ Ö
T
Ü á
>
á à
convertOutput
â ñ
,
ñ ó

Dictionary
ò ¢
<
¢ £
string
£ ©
,
© ™
object
´ ±
>
± ≤
?
≤ ≥

parameters
¥ æ
=
ø ¿
null
¡ ≈
)
≈ ∆
{ 	
PSCredential 

credential #
=$ %
credentialProvider& 8
.8 9
GetCredential9 F
(F G
)G H
;H I
WSManConnectionInfo 
wsManConnectionInfo  3
=4 5
new6 9
(9 :
): ;
{ 
ComputerName 
= 
param $
.$ %
Ip% '
,' (

Credential 
= 

credential '
} 
; 
return 
await *
PowershellRunNetworkRepository 7
.7 8
RunCommandInSpace8 I
(I J
wsManConnectionInfoJ ]
,] ^
command_ f
,f g
convertOutputh u
,u v

parameters	w Å
)
Å Ç
;
Ç É
} 	
	protected!! 
T!! 
ConvertOutput!! !
<!!! "
T!!" #
>!!# $
(!!$ %
string!!% +

jsonOutput!!, 6
,!!6 7
string!!8 >
	ipAddress!!? H
)!!H I
where!!J O
T!!P Q
:!!R S
BaseInfoDataModel!!T e
{"" 	
T## 
result## 
=## 
JsonSerializer## %
.##% &
Deserialize##& 1
<##1 2
T##2 3
>##3 4
(##4 5

jsonOutput##5 ?
)##? @
;##@ A
result$$ 
.$$ 
	IpAddress$$ 
=$$ 
	ipAddress$$ (
;$$( )
TimeZoneInfo%% 
brasiliaTimeZone%% )
=%%* +
TimeZoneInfo%%, 8
.%%8 9"
FindSystemTimeZoneById%%9 O
(%%O P
$str%%P p
)%%p q
;%%q r
DateTime&& 
brasiliaTime&& !
=&&" #
TimeZoneInfo&&$ 0
.&&0 1
ConvertTimeFromUtc&&1 C
(&&C D
DateTime&&D L
.&&L M
UtcNow&&M S
,&&S T
brasiliaTimeZone&&U e
)&&e f
;&&f g
result'' 
.'' 
	Timestamp'' 
='' 
brasiliaTime'' +
;''+ ,
return(( 
result(( 
;(( 
})) 	
},, 
}-- Á

|C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Powershell\ConfigurationRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .

Powershell. 8
{ 
public 

class #
ConfigurationRepository (
{ 
private 
IConfigurationRoot "
Configuration# 0
{1 2
get3 6
;6 7
}8 9
public		 #
ConfigurationRepository		 &
(		& '
)		' (
{

 	
Configuration 
= 
new  
ConfigurationBuilder  4
(4 5
)5 6
. 
AddJsonFile 
( 
$str /
)/ 0
. 
Build 
( 
) 
; 
} 	
public 
string 
GetValue 
( 
string %
key& )
)) *
{ 	
return 
Configuration  
.  !

GetSection! +
(+ ,
key, /
)/ 0
.0 1
Value1 6
??7 9
string: @
.@ A
EmptyA F
;F G
} 	
} 
} û
ÅC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Powershell\CredentialProviderRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .

Powershell. 8
{ 
public 

class (
CredentialProviderRepository -
{ 
private 
readonly #
ConfigurationRepository 0
	configRep1 :
=; <
new= @
(@ A
)A B
;B C
public

 
PSCredential

 
GetCredential

 )
(

) *
)

* +
{ 	
string 
username 
= 
	configRep '
.' (
GetValue( 0
(0 1
$str1 G
)G H
;H I
string 
password 
= 
	configRep '
.' (
GetValue( 0
(0 1
$str1 G
)G H
;H I
SecureString 
secureString %
=& '
new( +
(+ ,
), -
;- .
foreach 
( 
char 
letter  
in! #
password$ ,
), -
{ 
secureString 
. 

AppendChar '
(' (
letter( .
). /
;/ 0
} 
return 
new 
PSCredential #
(# $
username$ ,
,, -
secureString. :
): ;
;; <
} 	
} 
} ¸#
ÉC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Powershell\PowershellRunNetworkRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .

Powershell. 8
{ 
public 

class *
PowershellRunNetworkRepository /
{		 
public

 
static

 
async

 
Task

  
<

  !!
RepositoryResultModel

! 6
<

6 7
T

7 8
>

8 9
>

9 :
RunCommandInSpace

; L
<

L M
T

M N
>

N O
(

O P
WSManConnectionInfo 
wsManConnectionInfo  3
,3 4
string 
command 
, 
Func 
< 
string 
, 
T 
> 
convertOutput )
,) *

Dictionary 
< 
string 
, 
object %
>% &
?& '

parameters( 2
=3 4
null5 9
) 	
{ 	
using 
Runspace 
runSpace #
=$ %
RunspaceFactory& 5
.5 6
CreateRunspace6 D
(D E
wsManConnectionInfoE X
)X Y
;Y Z
try 
{ 
using 

PowerShell  

powerShell! +
=, -

PowerShell. 8
.8 9
Create9 ?
(? @
)@ A
;A B
runSpace 
. 
Open 
( 
) 
;  

powerShell 
. 
Runspace #
=$ %
runSpace& .
;. /
_ 
= 

powerShell 
. 
	AddScript (
(( )
command) 0
)0 1
;1 2
if 
( 

parameters 
!= !
null" &
)& '
{ 
foreach 
( 
KeyValuePair )
<) *
string* 0
,0 1
object2 8
>8 9
	parameter: C
inD F

parametersG Q
)Q R
{ 
_ 
= 

powerShell &
.& '
AddParameter' 3
(3 4
	parameter4 =
.= >
Key> A
,A B
	parameterC L
.L M
ValueM R
)R S
;S T
}   
}!! 
PSDataCollection##  
<##  !
PSObject##! )
>##) *
commandResult##+ 8
=##9 :
await##; @
Task##A E
.##E F
Factory##F M
.##M N
	FromAsync##N W
<##W X
PSDataCollection##X h
<##h i
PSObject##i q
>##q r
>##r s
(##s t

powerShell$$ 
.$$ 
BeginInvoke$$ *
($$* +
)$$+ ,
,$$, -

powerShell%% 
.%% 
	EndInvoke%% (
)%%( )
;%%) *
string&& 
returnResult&& #
=&&$ %
string&&& ,
.&&, -
Join&&- 1
(&&1 2
Environment&&2 =
.&&= >
NewLine&&> E
,&&E F
commandResult&&G T
)&&T U
;&&U V
T'' 
?'' 
convertedResult'' "
=''# $
convertOutput''% 2
(''2 3
returnResult''3 ?
)''? @
;''@ A
return)) 
new)) !
RepositoryResultModel)) 0
<))0 1
T))1 2
>))2 3
())3 4
data))4 8
:))8 9
convertedResult)): I
,))I J
success))K R
:))R S
convertedResult))T c
!=))d f
null))g k
)))k l
;))l m
}** 
catch++ 
(++ 
	Exception++ 
e++ 
)++ 
{,, 
return-- 
new-- !
RepositoryResultModel-- 0
<--0 1
T--1 2
>--2 3
(--3 4
error--4 9
:--9 :
new--; >!
ErrorRepositoryResult--? T
(--T U
e--U V
)--V W
)--W X
;--X Y
}.. 
finally// 
{00 
runSpace11 
.11 
Close11 
(11 
)11  
;11  !
}22 
}33 	
}44 
}55 Á	
C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallAdobeReaderRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class (
InstallAdobeReaderRepository -
:. /$
BasePowershellRepository0 H
,H I)
IInstallAdobeReaderRepositoryJ g
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 W
;

W X
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} €	
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallFirefoxRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class $
InstallFirefoxRepository )
:* +$
BasePowershellRepository, D
,D E%
IInstallFirefoxRepositoryF _
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 S
;

S T
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} Î	
ÄC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallGoogleChromeRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class )
InstallGoogleChromeRepository .
:/ 0$
BasePowershellRepository1 I
,I J*
IInstallGoogleChromeRepositoryK i
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 X
;

X Y
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} ·	
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallOffice365Repository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class &
InstallOffice365Repository +
:, -$
BasePowershellRepository. F
,F G'
IInstallOffice365RepositoryH c
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 ]
;

] ^
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} œ	
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallVlcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class  
InstallVlcRepository %
:& '$
BasePowershellRepository( @
,@ A!
IInstallVlcRepositoryB W
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 O
;

O P
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} ÿ	
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Software\InstallWinrarRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Software. 6
{ 
public 

class #
InstallWinrarRepository (
:) *$
BasePowershellRepository+ C
,C D$
IInstallWinrarRepositoryE ]
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 R
;

R S
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} ⁄
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\ChocolateyRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public		 

class		  
ChocolateyRepository		 %
:		& '
BaseMongoRepository		( ;
<		; <#
ChocolateyInfoDataModel		< S
>		S T
,		T U!
IChocolateyRepository		V k
{

 
public  
ChocolateyRepository #
(# $
MongoDbContext$ 2
	dbContext3 <
)< =
:> ?
base@ D
(D E
	dbContextE N
,N O
$strP `
)` a
{ 	
} 	
} 
} Å
C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\InstalledProgramsRepository.cs.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public		 

class		 '
InstalledProgramsRepository		 ,
:		- .
BaseMongoRepository		/ B
<		B C*
InstalledProgramsResponseModel		C a
>		a b
,		b c)
IInstalledProgramsRepository			d Ä
{

 
public '
InstalledProgramsRepository *
(* +
MongoDbContext+ 9
	dbContext: C
)C D
:E F
baseG K
(K L
	dbContextL U
,U V
$strW e
)e f
{ 	
} 	
} 
} ì
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\LocalChocolateyRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{		 
public

 

class

 %
LocalChocolateyRepository

 *
:

+ ,$
BasePowershellRepository

- E
,

E F&
ILocalChocolateyRepository

G a
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0#
ChocolateyInfoDataModel0 G
>G H
>H I
ExecCommandJ U
(U V*
RepositoryPowerShellParamModelV t
paramu z
)z {
{ 	
string 
command 
= 
$str Y
;Y Z
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4
output5 ;
=>< >
ConvertOutput? L
<L M#
ChocolateyInfoDataModelM d
>d e
(e f
outputf l
,l m
paramn s
.s t
Ipt v
)v w
)w x
;x y
} 	
private #
ChocolateyInfoDataModel '
ConvertOutput( 5
(5 6
string6 <
output= C
,C D
stringE K
ipL N
)N O
{ 	
string 
[ 
] 
lines 
= 
output #
.# $
Split$ )
() *
new* -
[- .
]. /
{0 1
$str2 8
,8 9
$str: >
,> ?
$str@ D
}E F
,F G
StringSplitOptionsH Z
.Z [
RemoveEmptyEntries[ m
)m n
;n o
TimeZoneInfo 
brasiliaTimeZone )
=* +
TimeZoneInfo, 8
.8 9"
FindSystemTimeZoneById9 O
(O P
$strP p
)p q
;q r
DateTime 
brasiliaTime !
=" #
TimeZoneInfo$ 0
.0 1
ConvertTimeFromUtc1 C
(C D
DateTimeD L
.L M
UtcNowM S
,S T
brasiliaTimeZoneU e
)e f
;f g
return 
new #
ChocolateyInfoDataModel .
{ 
ChocolateyVersion !
=" #
lines$ )
[) *
$num* +
]+ ,
., -
Trim- 1
(1 2
)2 3
,3 4
	IpAddress 
= 
ip 
, 
PSComputerName 
=  
lines! &
.& '
Length' -
>. /
$num0 1
?2 3
lines4 9
[9 :
$num: ;
]; <
.< =
Trim= A
(A B
)B C
:D E
stringF L
.L M
EmptyM R
,R S
	Timestamp 
= 
brasiliaTime (
} 
; 
} 	
}   
}!! õ
ÅC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\LocalInstalledProgramsRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{		 
public

 

class

 ,
 LocalInstalledProgramsRepository

 1
:

2 3$
BasePowershellRepository

4 L
,

L M-
!ILocalInstalledProgramsRepository

N o
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0*
InstalledProgramsResponseModel0 N
>N O
>O P
ExecCommandQ \
(\ ]*
RepositoryPowerShellParamModel] {
param	| Å
)
Å Ç
{ 	
string 
command 
= 
$str% 
;%% 
return'' 
await'' 
ExecCommand'' $
(''$ %
param''% *
,''* +
command'', 3
,''3 4

jsonOutput''5 ?
=>''@ B
ConvertOutput''C P
<''P Q*
InstalledProgramsResponseModel''Q o
>''o p
(''p q

jsonOutput''q {
,''{ |
param	''} Ç
.
''Ç É
Ip
''É Ö
)
''Ö Ü
)
''Ü á
;
''á à
}(( 	
})) 
}** â
yC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\LocalOsVersionRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{		 
public

 

class

 $
LocalOsVersionRepository

 )
:

* +$
BasePowershellRepository

, D
,

D E%
ILocalOsVersionRepository

F _
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0"
OSVersionInfoDataModel0 F
>F G
>G H
ExecCommandI T
(T U*
RepositoryPowerShellParamModelU s
paramt y
)y z
{ 	
string 
command 
= 
$str R
+S T
$str	 ê
;
ê ë
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B
ConvertOutputC P
<P Q"
OSVersionInfoDataModelQ g
>g h
(h i

jsonOutputi s
,s t
paramu z
.z {
Ip{ }
)} ~
)~ 
;	 Ä
} 	
} 
} –

uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\LocalUsersRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{		 
public

 

class

  
LocalUsersRepository

 %
:

& '$
BasePowershellRepository

( @
,

@ A!
ILocalUsersRepository

B W
{ 
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
UsersInfoDataModel0 B
>B C
>C D
ExecCommandE P
(P Q*
RepositoryPowerShellParamModelQ o
paramp u
)u v
{ 	
string 
command 
= 
$str 
; 
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B
ConvertOutputC P
<P Q
UsersInfoDataModelQ c
>c d
(d e

jsonOutpute o
,o p
paramq v
.v w
Ipw y
)y z
)z {
;{ |
} 	
} 
} ’
tC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\OsVersionRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public		 

class		 
OsVersionRepository		 $
:		% &
BaseMongoRepository		' :
<		: ;"
OSVersionInfoDataModel		; Q
>		Q R
,		R S 
IOsVersionRepository		T h
{

 
public 
OsVersionRepository "
(" #
MongoDbContext# 1
	dbContext2 ;
); <
:= >
base? C
(C D
	dbContextD M
,M N
$strO ^
)^ _
{ 	
} 	
} 
} »	
tC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\RestartPcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public 

class 
RestartPcRepository $
:% &$
BasePowershellRepository' ?
,? @ 
IRestartPcRepositoryA U
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 J
;

J K
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} À	
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\ShutdownPcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public 

class  
ShutdownPcRepository %
:& '$
BasePowershellRepository( @
,@ A!
IShutdownPcRepositoryB W
{		 
private

 
static

 
readonly

 
string

  &
command

' .
=

/ 0
$str

1 G
;

G H
public 
async 
Task 
< !
RepositoryResultModel /
</ 0
string0 6
>6 7
>7 8
ExecCommand9 D
(D E*
RepositoryPowerShellParamModelE c
paramd i
)i j
{ 	
return 
await 
ExecCommand $
($ %
param% *
,* +
command, 3
,3 4

jsonOutput5 ?
=>@ B

jsonOutputC M
)M N
;N O
} 	
} 
} ¡
pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\System\UsersRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
System. 4
{ 
public		 

class		 
UsersRepository		  
:		! "
BaseMongoRepository		# 6
<		6 7
UsersInfoDataModel		7 I
>		I J
,		J K
IUsersRepository		L \
{

 
public 
UsersRepository 
( 
MongoDbContext -
	dbContext. 7
)7 8
:9 :
base; ?
(? @
	dbContext@ I
,I J
$strK U
)U V
{ 	
} 	
} 
} ˘
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Upload\FileUploadService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Upload		- 3
{

 
public 

class 
FileUploadService "
:# $
IFileUploadService% 7
{ 
private 
readonly !
IUploadFileRepository .!
_uploadFileRepository/ D
;D E
public 
FileUploadService  
(  !!
IUploadFileRepository! 6 
uploadFileRepository7 K
)K L
{ 	!
_uploadFileRepository !
=" # 
uploadFileRepository$ 8
;8 9
} 	
public 
ServiceResultModel !
<! "
string" (
>( )

UploadFile* 4
(4 5
	IFormFile5 >
file? C
)C D
{ 	
string 
destinationFolder $
=% &
$str' 0
;0 1
byte 
[ 
] 
fileData 
= 
	FileUtils '
.' (
ReadFileData( 4
(4 5
file5 9
)9 :
;: ;!
RepositoryResultModel !
<! "
UploadResult" .
>. /
	resultRep0 9
=: ;!
_uploadFileRepository< Q
.Q R

UploadFileR \
(\ ]
file] a
.a b
FileNameb j
,j k
fileDatal t
,t u
destinationFolder	v á
)
á à
;
à â
if 
( 
	resultRep 
. 
Success !
)! "
{ 
return 
new 
ServiceResultModel -
<- .
string. 4
>4 5
(5 6
success 
: 
new   
SuccessServiceResult! 5
<5 6
string6 <
>< =
(= >
	resultRep> G
.G H
DataH L
.L M
MessageM T
,T U
DateTimeV ^
.^ _
Now_ b
,b c
Environmentd o
.o p
MachineNamep {
){ |
) 
; 
} 
else   
{!! 
return"" 
new"" 
ServiceResultModel"" -
<""- .
string"". 4
>""4 5
(""5 6
error## 
:## 
new## 
ErrorServiceResult## 1
(##1 2
	resultRep##2 ;
.##; <
ErrorResult##< G
.##G H
Message##H O
,##O P
DateTime##Q Y
.##Y Z
Now##Z ]
,##] ^
Environment##_ j
.##j k
MachineName##k v
)##v w
)$$ 
;$$ 
}%% 
}&& 	
}(( 
})) ≤
jC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Upload\FileUtils.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementations .
.. /
Uploud/ 5
{		 
public

 

static

 
class

 
	FileUtils

 !
{ 
public 
static 
byte 
[ 
] 
ReadFileData )
() *
	IFormFile* 3
file4 8
)8 9
{ 	
using 
MemoryStream 
memoryStream +
=, -
new. 1
(1 2
)2 3
;3 4
file 
. 
CopyTo 
( 
memoryStream $
)$ %
;% &
return 
memoryStream 
.  
ToArray  '
(' (
)( )
;) *
} 	
public 
static 
void 
WriteFileData (
(( )
string) /
filePath0 8
,8 9
byte: >
[> ?
]? @
fileDataA I
)I J
{ 	
File 
. 
WriteAllBytes 
( 
filePath '
,' (
fileData) 1
)1 2
;2 3
} 	
} 
} «
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Upload\FileValidationService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
Upload- 3
{ 
public		 

class		 !
FileValidationService		 &
:		' ("
IFileValidationService		) ?
{

 
public 
ServiceResultModel !
<! "
object" (
>( )
ValidateFile* 6
(6 7
	IFormFile7 @
fileA E
)E F
{ 	
if 
( 
file 
== 
null 
|| 
file  $
.$ %
Length% +
==, .
$num/ 0
)0 1
{ 
return 
new 
ServiceResultModel -
<- .
object. 4
>4 5
(5 6
error 
: 
new 
ErrorServiceResult 1
(1 2
$str2 O
,O P
DateTimeQ Y
.Y Z
NowZ ]
,] ^
Environment_ j
.j k
MachineNamek v
)v w
) 
; 
} 
return 
new 
ServiceResultModel )
<) *
object* 0
>0 1
(1 2
success 
: 
new  
SuccessServiceResult 1
<1 2
object2 8
>8 9
(9 :
null: >
,> ?
DateTime@ H
.H I
NowI L
,L M
EnvironmentN Y
.Y Z
MachineNameZ e
)e f
) 
; 
} 	
} 
} É
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Implementations\Upload\UploadFileRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 
Implementation -
.- .
Uploud. 4
{ 
public 

class  
UploadFileRepository %
:& '!
IUploadFileRepository( =
{ 
public		 !
RepositoryResultModel		 $
<		$ %
UploadResult		% 1
>		1 2

UploadFile		3 =
(		= >
string		> D
fileName		E M
,		M N
byte		O S
[		S T
]		T U
fileData		V ^
,		^ _
string		` f
destinationFolder		g x
)		x y
{

 	
try 
{ 
string 
filePath 
=  !
Path" &
.& '
Combine' .
(. /
destinationFolder/ @
,@ A
fileNameB J
)J K
;K L
WriteFileData 
( 
filePath &
,& '
fileData( 0
)0 1
;1 2
return 
new !
RepositoryResultModel 0
<0 1
UploadResult1 =
>= >
(> ?
data 
: 
new 
UploadResult *
{ 
FilePath  
=! "
filePath# +
,+ ,
Message 
=  !
$str" ?
} 
, 
success 
: 
true !
) 
; 
} 
catch 
( 
	Exception 
e 
) 
{ 
return 
new !
RepositoryResultModel 0
<0 1
UploadResult1 =
>= >
(> ?
error? D
:D E
newF I!
ErrorRepositoryResultJ _
(_ `
e` a
)a b
)b c
;c d
} 
} 	
private   
void   
WriteFileData   "
(  " #
string  # )
filePath  * 2
,  2 3
byte  4 8
[  8 9
]  9 :
fileData  ; C
)  C D
{!! 	
File"" 
."" 
WriteAllBytes"" 
("" 
filePath"" '
,""' (
fileData"") 1
)""1 2
;""2 3
}## 	
}$$ 
}%% Ü
nC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Base\IBaseMongoRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Base* .
{		 
public 

	interface  
IBaseMongoRepository )
<) *
T* +
>+ ,
where- 2
T3 4
:5 6
BaseInfoDataModel7 H
{ 
Task 
< 
IEnumerable 
< 
T 
> 
> 
GetAllAsync (
(( )
)) *
;* +
Task 
< 
T 
> "
GetByComputerNameAsync &
(& '
string' -
computerName. :
): ;
;; <
Task 
InsertAsync 
( 
T 
entity !
)! "
;" #
Task 
UpdateAsync 
( 
T 
entity !
)! "
;" #
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &,
 GetMostRecentByComputerNameAsync' G
(G H
stringH N
computerNameO [
)[ \
;\ ]
} 
} °	
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Base\IBasePowershellRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Base* .
{ 
[ 
AutoDI 
] 
public		 

	interface		 %
IBasePowershellRepository		 .
{

 
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &
ExecCommand' 2
<2 3
T3 4
>4 5
(5 6*
RepositoryPowerShellParamModel6 T
paramU Z
,Z [
string\ b
commandc j
,j k
Funcl p
<p q
stringq w
,w x
Ty z
>z {
convertOutput	| â
,
â ä

Dictionary
ã ï
<
ï ñ
string
ñ ú
,
ú ù
object
û §
>
§ •
?
• ¶

parameters
ß ±
=
≤ ≥
null
¥ ∏
)
∏ π
;
π ∫
} 
} ¨
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Hardware\IHardwareRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Hardware* 2
{		 
[

 
AutoDI

 
]

 
public 

	interface 
IHardwareRepository (
<( )
T) *
>* +
:, - 
IBaseMongoRepository. B
<B C
TC D
>D E
whereF K
TL M
:N O
BaseInfoDataModelP a
{ 
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &,
 GetMostRecentByComputerNameAsync' G
(G H
stringH N
computerNameO [
)[ \
;\ ]
} 
} »
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Hardware\ILocalHardwareRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Hardware* 2
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 $
ILocalHardwareRepository

 -
<

- .
T

. /
>

/ 0
where

1 6
T

7 8
:

9 :
class

; @
{ 
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &
ExecCommand' 2
(2 3*
RepositoryPowerShellParamModel3 Q
paramR W
)W X
;X Y
} 
} ™
lC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Hardware\IRamRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Hardware* 2
{ 
[ 
AutoDI 
] 
public 

	interface 
IRamRepository #
:$ %
IHardwareRepository& 9
<9 :
RamInfoDataModel: J
>J K
{		 
}

 
} ∂
pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Hardware\IStorageRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Hardware* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IStorageRepository		 '
:		( )
IHardwareRepository		* =
<		= > 
StorageInfoDataModel		> R
>		R S
{

 
} 
} Ê
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallAdobeReaderRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 )
IInstallAdobeReaderRepository		 2
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} “
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstalledProgramsRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{		 
[

 
AutoDI

 
]

 
public 

	interface (
IInstalledProgramsRepository 1
:2 3
ISystemRepository4 E
<E F*
InstalledProgramsResponseModelF d
>d e
{ 
} 
} ﬁ
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallFirefoxRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 %
IInstallFirefoxRepository		 .
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} Ë
|C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallGoogleChromeRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 *
IInstallGoogleChromeRepository		 3
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} ‚
yC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallOffice365Repository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 '
IInstallOffice365Repository		 0
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} ÷
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallVlcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 !
IInstallVlcRepository		 *
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} ‹
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Software\IInstallWinrarRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Software* 2
{ 
[ 
AutoDI 
] 
public		 

	interface		 $
IInstallWinrarRepository		 -
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} π
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\IChocolateyRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[ 
AutoDI 
] 
public 

	interface !
IChocolateyRepository *
:+ ,
ISystemRepository- >
<> ?#
ChocolateyInfoDataModel? V
>V W
{		 
}

 
} „
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalChocolateyRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 &
ILocalChocolateyRepository

 /
:

0 1"
ILocalSystemRepository

2 H
<

H I#
ChocolateyInfoDataModel

I `
>

` a
{ 
Task 
< !
RepositoryResultModel "
<" ##
ChocolateyInfoDataModel# :
>: ;
>; <
ExecCommand= H
(H I*
RepositoryPowerShellParamModelI g
paramh m
)m n
;n o
} 
} ˇ
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalInstalledProgramsRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 -
!ILocalInstalledProgramsRepository

 6
:

7 8"
ILocalSystemRepository

9 O
<

O P*
InstalledProgramsResponseModel

P n
>

n o
{ 
Task 
< !
RepositoryResultModel "
<" #*
InstalledProgramsResponseModel# A
>A B
>B C
ExecCommandD O
(O P*
RepositoryPowerShellParamModelP n
paramo t
)t u
;u v
} 
} ﬂ
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalOsVersionRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 %
ILocalOsVersionRepository

 .
:

/ 0"
ILocalSystemRepository

1 G
<

G H"
OSVersionInfoDataModel

H ^
>

^ _
{ 
Task 
< !
RepositoryResultModel "
<" #"
OSVersionInfoDataModel# 9
>9 :
>: ;
ExecCommand< G
(G H*
RepositoryPowerShellParamModelH f
paramg l
)l m
;m n
} 
} …
oC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalRamRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{		 
[

 
AutoDI

 
]

 
public 

	interface 
ILocalRamRepository (
:) *$
ILocalHardwareRepository+ C
<C D
RamInfoDataModelD T
>T U
{ 
Task 
< !
RepositoryResultModel "
<" #
RamInfoDataModel# 3
>3 4
>4 5
ExecCommand6 A
(A B*
RepositoryPowerShellParamModelB `
parama f
)f g
;g h
} 
} è
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalStorageRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[ 
AutoDI 
] 
public 

	interface #
ILocalStorageRepository ,
:- .$
ILocalHardwareRepository/ G
<G H 
StorageInfoDataModelH \
>\ ]
,] ^%
IBasePowershellRepository_ x
{ 
Task 
< !
RepositoryResultModel "
<" # 
StorageInfoDataModel# 7
>7 8
>8 9
ExecCommand: E
(E F*
RepositoryPowerShellParamModelF d
parame j
)j k
;k l
} 
} ¿
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalSystemRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 "
ILocalSystemRepository		 +
<		+ ,
T		, -
>		- .
where		/ 4
T		5 6
:		7 8
class		9 >
{

 
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &
ExecCommand' 2
(2 3*
RepositoryPowerShellParamModel3 Q
paramR W
)W X
;X Y
} 
} œ
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ILocalUsersRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 !
ILocalUsersRepository

 *
:

+ ,"
ILocalSystemRepository

- C
<

C D
UsersInfoDataModel

D V
>

V W
{ 
Task 
< !
RepositoryResultModel "
<" #
UsersInfoDataModel# 5
>5 6
>6 7
ExecCommand8 C
(C D*
RepositoryPowerShellParamModelD b
paramc h
)h i
;i j
} 
} ∂
pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\IOsVersionRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

  
IOsVersionRepository

 )
:

* +
ISystemRepository

, =
<

= >"
OSVersionInfoDataModel

> T
>

T U
{ 
} 
} –
pC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\IRestartPcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[ 
AutoDI 
] 
public		 

	interface		  
IRestartPcRepository		 )
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} “
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\IShutdownPcRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 !
IShutdownPcRepository		 *
{

 
Task 
< !
RepositoryResultModel "
<" #
string# )
>) *
>* +
ExecCommand, 7
(7 8*
RepositoryPowerShellParamModel8 V
paramW \
)\ ]
;] ^
} 
} §
mC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\ISystemRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{		 
[

 
AutoDI

 
]

 
public 

	interface 
ISystemRepository &
<& '
T' (
>( )
:* + 
IBaseMongoRepository, @
<@ A
TA B
>B C
whereD I
TJ K
:L M
BaseInfoDataModelN _
{ 
Task 
< !
RepositoryResultModel "
<" #
T# $
>$ %
>% &,
 GetMostRecentByComputerNameAsync' G
(G H
stringH N
computerNameO [
)[ \
;\ ]
} 
} ™
lC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\System\IUsersRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
System* 0
{ 
[		 
AutoDI		 
]		 
public

 

	interface

 
IUsersRepository

 %
:

& '
ISystemRepository

( 9
<

9 :
UsersInfoDataModel

: L
>

L M
{ 
} 
} Ä
nC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Upload\IFileUploadService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Upload( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IFileUploadService		 '
{

 
ServiceResultModel 
< 
string !
>! "

UploadFile# -
(- .
	IFormFile. 7
file8 <
)< =
;= >
} 
} ä
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Upload\IFileValidationService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Upload( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 "
IFileValidationService		 +
{

 
ServiceResultModel 
< 
object !
>! "
ValidateFile# /
(/ 0
	IFormFile0 9
file: >
)> ?
;? @
} 
} ©
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Repository\Interfaces\Upload\IUploadFileRepository.cs
	namespace 	
	NetMaster
 
. 

Repository 
. 

Interfaces )
.) *
Uploud* 0
{ 
[ 
AutoDI 
] 
public 

	interface !
IUploadFileRepository *
{		 !
RepositoryResultModel

 
<

 
UploadResult

 *
>

* +

UploadFile

, 6
(

6 7
string

7 =
fileName

> F
,

F G
byte

H L
[

L M
]

M N
fileData

O W
,

W X
string

Y _
destinationFolder

` q
)

q r
;

r s
} 
} 