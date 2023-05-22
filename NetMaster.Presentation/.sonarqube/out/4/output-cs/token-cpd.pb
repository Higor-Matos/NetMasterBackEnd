˛M
èC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\BackgroundServices\ComputerInfoBackgroundService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementations

 ,
.

, -
BackgroundServices

- ?
{ 
public 

class )
ComputerInfoBackgroundService .
:/ 0
BackgroundService1 B
,B C*
IComputerInfoBackgroundServiceD b
{ 
private 
readonly 
IServiceProvider )
_serviceProvider* :
;: ;
public )
ComputerInfoBackgroundService ,
(, -
IServiceProvider- =
serviceProvider> M
)M N
{ 	
_serviceProvider 
= 
serviceProvider .
;. /
} 	
	protected 
override 
async  
Task! %
ExecuteAsync& 2
(2 3
CancellationToken3 D
stoppingTokenE R
)R S
{ 	
while 
( 
! 
stoppingToken !
.! "#
IsCancellationRequested" 9
)9 :
{ 
using 
IServiceScope #
scope$ )
=* +
_serviceProvider, <
.< =
CreateScope= H
(H I
)I J
;J K
INetworkService 
networkService  .
=/ 0
scope1 6
.6 7
ServiceProvider7 F
.F G
GetRequiredServiceG Y
<Y Z
INetworkServiceZ i
>i j
(j k
)k l
;l m
await ,
 CollectAndStoreComputerInfoAsync 6
(6 7
networkService7 E
)E F
;F G
await 
Task 
. 
Delay  
(  !
TimeSpan! )
.) *
FromMinutes* 5
(5 6
$num6 8
)8 9
,9 :
stoppingToken; H
)H I
;I J
} 
} 	
private!! 
async!! 
Task!! ,
 CollectAndStoreComputerInfoAsync!! ;
(!!; <
INetworkService!!< K
networkService!!L Z
)!!Z [
{"" 	
NetworkComputer## 
[## 
]## 
	computers## '
=##( )
networkService##* 8
.##8 9&
ListNetworkComputerCommand##9 S
(##S T
)##T U
;##U V
foreach%% 
(%% 
NetworkComputer%% $
computer%%% -
in%%. 0
	computers%%1 :
)%%: ;
{&& 
string'' 
ip'' 
='' 
computer'' $
.''$ %
IP''% '
;''' (
using)) 
IServiceScope)) #
scope))$ )
=))* +
_serviceProvider)), <
.))< =
CreateScope))= H
())H I
)))I J
;))J K
(++ 
ISystemService++ 
ISystemService++  .
,++. /
IRamInfoService++0 ?
RamInfoService++@ N
,++N O
IStorageInfoService++P c
StorageInfoService++d v
,++v w#
IChocolateyInfoService	++x é#
ChocolateyInfoService
++è §
,
++§ •+
IInstalledProgramsInfoService
++¶ √*
InstalledProgramsInfoService
++ƒ ‡
,
++‡ ·#
IOsVersionInfoService
++‚ ˜"
OsVersionInfoService
++¯ å
,
++å ç
IUsersInfoService
++é ü
UserInfoService
++† Ø
)
++Ø ∞
services
++± π
=
++∫ ª!
GetRequiredServices
++º œ
(
++œ –
scope
++– ’
.
++’ ÷
ServiceProvider
++÷ Â
)
++Â Ê
;
++Ê Á
List-- 
<-- 
Task-- 
>-- 
tasks--  
=--! "
new--# &
(--& '
)--' (
{.. 
services// 
.// 
RamInfoService// +
.//+ ,!
SaveLocalRamInfoAsync//, A
(//A B
ip//B D
)//D E
,//E F
services00 
.00 
StorageInfoService00 /
.00/ 0%
SaveLocalStorageInfoAsync000 I
(00I J
ip00J L
)00L M
,00M N
services11 
.11 
UserInfoService11 ,
.11, -$
SaveLocalSystemInfoAsync11- E
(11E F
ip11F H
)11H I
,11I J
services22 
.22  
OsVersionInfoService22 1
.221 2$
SaveLocalSystemInfoAsync222 J
(22J K
ip22K M
)22M N
,22N O
services33 
.33 (
InstalledProgramsInfoService33 9
.339 :$
SaveLocalSystemInfoAsync33: R
(33R S
ip33S U
)33U V
,33V W
services44 
.44 !
ChocolateyInfoService44 2
.442 3$
SaveLocalSystemInfoAsync443 K
(44K L
ip44L N
)44N O
}55 
;55 
await77 
Task77 
.77 
WhenAll77 "
(77" #
tasks77# (
)77( )
;77) *
}88 
}99 	
Task;; *
IComputerInfoBackgroundService;; +
.;;+ ,,
 CollectAndStoreComputerInfoAsync;;, L
(;;L M
);;M N
{<< 	
throw== 
new== #
NotImplementedException== -
(==- .
)==. /
;==/ 0
}>> 	
Task@@ *
IComputerInfoBackgroundService@@ +
.@@+ ,
ExecuteAsync@@, 8
(@@8 9
CancellationToken@@9 J
stoppingToken@@K X
)@@X Y
{AA 	
throwBB 
newBB #
NotImplementedExceptionBB -
(BB- .
)BB. /
;BB/ 0
}CC 	
privateEE 
(EE 
ISystemServiceFF 
SystemServiceFF (
,FF( )
IRamInfoServiceGG 
RamInfoServiceGG *
,GG* +
IStorageInfoServiceHH 
StorageInfoServiceHH  2
,HH2 3"
IChocolateyInfoServiceII "!
ChocolateyInfoServiceII# 8
,II8 9)
IInstalledProgramsInfoServiceJJ )(
InstalledProgramsInfoServiceJJ* F
,JJF G!
IOsVersionInfoServiceKK ! 
OsVersionInfoServiceKK" 6
,KK6 7
IUsersInfoServiceLL 
UserInfoServiceLL -
)MM 	
GetRequiredServicesMM
 
(MM 
IServiceProviderMM .
serviceProviderMM/ >
)MM> ?
{NN 	
ISystemServiceOO 
systemServiceOO (
=OO) *
serviceProviderOO+ :
.OO: ;
GetRequiredServiceOO; M
<OOM N
ISystemServiceOON \
>OO\ ]
(OO] ^
)OO^ _
;OO_ `
IRamInfoServicePP 
ramInfoServicePP *
=PP+ ,
serviceProviderPP- <
.PP< =
GetRequiredServicePP= O
<PPO P
IRamInfoServicePPP _
>PP_ `
(PP` a
)PPa b
;PPb c
IStorageInfoServiceQQ 
storageInfoServiceQQ  2
=QQ3 4
serviceProviderQQ5 D
.QQD E
GetRequiredServiceQQE W
<QQW X
IStorageInfoServiceQQX k
>QQk l
(QQl m
)QQm n
;QQn o"
IChocolateyInfoServiceRR "!
chocolateyInfoServiceRR# 8
=RR9 :
serviceProviderRR; J
.RRJ K
GetRequiredServiceRRK ]
<RR] ^"
IChocolateyInfoServiceRR^ t
>RRt u
(RRu v
)RRv w
;RRw x)
IInstalledProgramsInfoServiceSS )(
installedProgramsInfoServiceSS* F
=SSG H
serviceProviderSSI X
.SSX Y
GetRequiredServiceSSY k
<SSk l*
IInstalledProgramsInfoService	SSl â
>
SSâ ä
(
SSä ã
)
SSã å
;
SSå ç!
IOsVersionInfoServiceTT ! 
osVersionInfoServiceTT" 6
=TT7 8
serviceProviderTT9 H
.TTH I
GetRequiredServiceTTI [
<TT[ \!
IOsVersionInfoServiceTT\ q
>TTq r
(TTr s
)TTs t
;TTt u
IUsersInfoServiceUU 
usersInfoServiceUU .
=UU/ 0
serviceProviderUU1 @
.UU@ A
GetRequiredServiceUUA S
<UUS T
IUsersInfoServiceUUT e
>UUe f
(UUf g
)UUg h
;UUh i
returnWW 
(WW 
systemServiceXX 
,XX 
ramInfoServiceYY 
,YY 
storageInfoServiceZZ "
,ZZ" #!
chocolateyInfoService[[ %
,[[% &(
installedProgramsInfoService\\ ,
,\\, - 
osVersionInfoService]] $
,]]$ %
usersInfoService^^  
)__ 
;__ 
}`` 	
(bb 	
ISystemServicebb	 
SystemServicebb %
,bb% &
IRamInfoServicebb' 6
RamInfoServicebb7 E
,bbE F
IStorageInfoServicebbG Z
StorageInfoServicebb[ m
,bbm n#
IChocolateyInfoService	bbo Ö#
ChocolateyInfoService
bbÜ õ
,
bbõ ú+
IInstalledProgramsInfoService
bbù ∫*
InstalledProgramsInfoService
bbª ◊
,
bb◊ ÿ#
IOsVersionInfoService
bbŸ Ó"
OsVersionInfoService
bbÔ É
,
bbÉ Ñ
IUsersInfoService
bbÖ ñ
UserInfoService
bbó ¶
)
bb¶ ß,
IComputerInfoBackgroundService
bb® ∆
.
bb∆ «!
GetRequiredServices
bb« ⁄
(
bb⁄ €
IServiceProvider
bb€ Î
serviceProvider
bbÏ ˚
)
bb˚ ¸
{cc 	
throwdd 
newdd #
NotImplementedExceptiondd -
(dd- .
)dd. /
;dd/ 0
}ee 	
}ff 
}gg ˝
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\BaseCommand\BaseService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
BaseCommands- 9
{ 
public 

abstract 
class 
BaseService %
:& '
IBaseService( 4
{		 
private

 
readonly

 
ICommandRunner

 '
_commandRunner

( 6
;

6 7
private 
readonly 
IResultConverter )
_resultConverter* :
;: ;
	protected 
BaseService 
( 
ICommandRunner ,
commandRunner- :
,: ;
IResultConverter< L
resultConverterM \
)\ ]
{ 	
_commandRunner 
= 
commandRunner *
;* +
_resultConverter 
= 
resultConverter .
;. /
} 	
public 
ServiceResultModel !
<! "
T" #
># $

RunCommand% /
</ 0
T0 1
>1 2
(2 3!
RepositoryResultModel3 H
<H I
TI J
>J K
resultL R
)R S
whereT Y
TZ [
:\ ]
class^ c
{ 	
return 
_commandRunner !
.! "
Run" %
(% &
result& ,
), -
;- .
} 	
public !
RepositoryResultModel $
<$ %
object% +
>+ ,
ConvertResult- :
(: ;!
RepositoryResultModel; P
<P Q
stringQ W
>W X
resultY _
)_ `
{ 	
return 
_resultConverter #
.# $
Convert$ +
(+ ,
result, 2
)2 3
;3 4
} 	
	protected 
ServiceResultModel $
<$ %
T% &
>& '
CreateServiceResult( ;
<; <
T< =
>= >
(> ?
T? @
dataA E
,E F
stringG M
errorMessageN Z
,Z [
string\ b
ipc e
)e f
whereg l
Tm n
:o p
BaseInfoDataModel	q Ç
{ 	
return 
data 
!= 
null 
?   
new   
ServiceResultModel   (
<  ( )
T  ) *
>  * +
(  + ,
success!! 
:!! 
new!!   
SuccessServiceResult!!! 5
<!!5 6
T!!6 7
>!!7 8
(!!8 9
data!!9 =
,!!= >
DateTime!!? G
.!!G H
UtcNow!!H N
,!!N O
ip!!P R
)!!R S
)"" 
:## 
new## 
ServiceResultModel## (
<##( )
T##) *
>##* +
(##+ ,
error$$ 
:$$ 
new$$ 
ErrorServiceResult$$ 1
($$1 2
errorMessage$$2 >
,$$> ?
DateTime$$@ H
.$$H I
UtcNow$$I O
,$$O P
ip$$Q S
)$$S T
)%% 
;%% 
}&& 	
}'' 
}(( æ
xC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\BaseCommand\CommandRunner.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
BaseCommands- 9
{ 
public 

class 
CommandRunner 
:  
ICommandRunner! /
{ 
public		 
ServiceResultModel		 !
<		! "
T		" #
>		# $
Run		% (
<		( )
T		) *
>		* +
(		+ ,!
RepositoryResultModel		, A
<		A B
T		B C
>		C D
result		E K
)		K L
where		M R
T		S T
:		U V
class		W \
{

 	
DateTime 
	timestamp 
=  
DateTime! )
.) *
UtcNow* 0
;0 1
string 
computerName 
=  !
Environment" -
.- .
MachineName. 9
;9 :
if 
( 
result 
. 
SuccessResult $
!=% '
null( ,
), -
{  
SuccessServiceResult $
<$ %
T% &
>& '
successResult( 5
=6 7
new8 ;
(; <
result< B
.B C
SuccessResultC P
.P Q
ResultQ W
,W X
	timestampY b
,b c
computerNamed p
)p q
;q r
return 
new 
ServiceResultModel -
<- .
T. /
>/ 0
(0 1
success1 8
:8 9
successResult: G
)G H
;H I
} 
else 
{ 
string 
msgError 
=  !
result" (
.( )
ErrorResult) 4
?4 5
.5 6
	Exception6 ?
.? @
Message@ G
??H J
$strK ]
;] ^
ErrorServiceResult "
errorResult# .
=/ 0
new1 4
(4 5
msgError5 =
,= >
	timestamp? H
,H I
computerNameJ V
)V W
;W X
return 
new 
ServiceResultModel -
<- .
T. /
>/ 0
(0 1
error1 6
:6 7
errorResult8 C
)C D
;D E
} 
} 	
} 
} 
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\BaseCommand\ResultConverter.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
BaseCommands- 9
{ 
public 

class 
ResultConverter  
:! "
IResultConverter# 3
{ 
public		 !
RepositoryResultModel		 $
<		$ %
object		% +
>		+ ,
Convert		- 4
(		4 5!
RepositoryResultModel		5 J
<		J K
string		K Q
>		Q R
result		S Y
)		Y Z
{

 	
return 
result 
. 
SuccessResult '
!=( *
null+ /
? 
new !
RepositoryResultModel +
<+ ,
object, 2
>2 3
(3 4
data4 8
:8 9
result: @
.@ A
SuccessResultA N
.N O
ResultO U
,U V
successW ^
:^ _
true` d
,d e
errorf k
:k l
resultm s
.s t
ErrorResultt 
)	 Ä
: 
new !
RepositoryResultModel +
<+ ,
object, 2
>2 3
(3 4
success4 ;
:; <
false= B
,B C
errorD I
:I J
resultK Q
.Q R
ErrorResultR ]
)] ^
;^ _
} 	
} 
} «.
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Hardware\HardwareInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
Hardware- 5
{ 
public 

abstract 
class 
HardwareInfoService -
<- .
T. /
>/ 0
:1 2
BaseService3 >
where? D
TE F
:G H
BaseInfoDataModelI Z
{ 
	protected 
readonly 
IHardwareRepository .
<. /
T/ 0
>0 1
_hardwareRepository2 E
;E F
	protected 
readonly $
ILocalHardwareRepository 3
<3 4
T4 5
>5 6$
_localHardwareRepository7 O
;O P
public 
HardwareInfoService "
(" #
IHardwareRepository# 6
<6 7
T7 8
>8 9
hardwareRepository: L
,L M$
ILocalHardwareRepositoryN f
<f g
Tg h
>h i$
localHardwareRepository	j Å
,
Å Ç
ICommandRunner
É ë
commandRunner
í ü
,
ü †
IResultConverter
° ±
resultConverter
≤ ¡
)
¡ ¬
:
√ ƒ
base
≈ …
(
…  
commandRunner
  ◊
,
◊ ÿ
resultConverter
Ÿ Ë
)
Ë È
{ 	
_hardwareRepository 
=  !
hardwareRepository" 4
;4 5$
_localHardwareRepository $
=% &#
localHardwareRepository' >
;> ?
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
T- .
>. /
>/ 0&
SaveLocalHardwareInfoAsync1 K
(K L
stringL R
ipS U
)U V
{ 	!
RepositoryResultModel !
<! "
T" #
># $#
localHardwareInfoResult% <
== >
await? D$
_localHardwareRepositoryE ]
.] ^
ExecCommand^ i
(i j
newj m+
RepositoryPowerShellParamModel	n å
(
å ç
ip
ç è
)
è ê
)
ê ë
;
ë í
if 
( #
localHardwareInfoResult '
.' (
SuccessResult( 5
!=6 8
null9 =
)= >
{ 
await 
_hardwareRepository )
.) *
InsertAsync* 5
(5 6#
localHardwareInfoResult6 M
.M N
SuccessResultN [
.[ \
Result\ b
)b c
;c d 
SuccessServiceResult $
<$ %
T% &
>& '
successResult( 5
=6 7
new8 ;
(; <#
localHardwareInfoResult< S
.S T
SuccessResultT a
.a b
Resultb h
,h i
DateTimej r
.r s
UtcNows y
,y z
ip{ }
)} ~
;~ 
return 
new 
ServiceResultModel -
<- .
T. /
>/ 0
(0 1
successResult1 >
)> ?
;? @
}   
else!! 
if!! 
(!! #
localHardwareInfoResult!! ,
.!!, -
ErrorResult!!- 8
!=!!9 ;
null!!< @
)!!@ A
{"" 
ErrorServiceResult## "
errorResult### .
=##/ 0
new##1 4
(##4 5#
localHardwareInfoResult##5 L
.##L M
ErrorResult##M X
.##X Y
	Exception##Y b
.##b c
Message##c j
,##j k
DateTime##l t
.##t u
UtcNow##u {
,##{ |
ip##} 
)	## Ä
;
##Ä Å
return$$ 
new$$ 
ServiceResultModel$$ -
<$$- .
T$$. /
>$$/ 0
($$0 1
error$$1 6
:$$6 7
errorResult$$8 C
)$$C D
;$$D E
}%% 
else&& 
{'' 
ErrorServiceResult(( "
errorResult((# .
=((/ 0
new((1 4
(((4 5
$"((5 7
$str((7 Y
"((Y Z
,((Z [
DateTime((\ d
.((d e
UtcNow((e k
,((k l
ip((m o
)((o p
;((p q
return)) 
new)) 
ServiceResultModel)) -
<))- .
T)). /
>))/ 0
())0 1
error))1 6
:))6 7
errorResult))8 C
)))C D
;))D E
}** 
}++ 	
public-- 
async-- 
Task-- 
<-- 
ServiceResultModel-- ,
<--, -
T--- .
>--. /
>--/ 0.
"GetHardwareInfoByComputerNameAsync--1 S
(--S T
string--T Z
computerName--[ g
)--g h
{.. 	
T// 
hardwareInfo// 
=// 
await// "
_hardwareRepository//# 6
.//6 7"
GetByComputerNameAsync//7 M
(//M N
computerName//N Z
)//Z [
;//[ \ 
SuccessServiceResult00  
<00  !
T00! "
>00" #
successResult00$ 1
=002 3
new004 7
(007 8
hardwareInfo008 D
,00D E
DateTime00F N
.00N O
UtcNow00O U
,00U V
computerName00W c
)00c d
;00d e
return11 
new11 
ServiceResultModel11 )
<11) *
T11* +
>11+ ,
(11, -
successResult11- :
)11: ;
;11; <
}22 	
}33 
}44 ≤
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Hardware\HardwareService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Hardware		- 5
{

 
public 

class 
HardwareService  
:! "
BaseService# .
,. /
IHardwareService0 @
{ 
private 
readonly 
IRamInfoService (
_ramInfoService) 8
;8 9
private 
readonly 
IStorageInfoService ,
_storageInfoService- @
;@ A
public 
HardwareService 
( 
IRamInfoService 
ramInfoService *
,* +
IStorageInfoService 
storageInfoService  2
,2 3
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
commandRunner 
, 
resultConverter  /
)/ 0
{ 	
_ramInfoService 
= 
ramInfoService ,
;, -
_storageInfoService 
=  !
storageInfoService" 4
;4 5
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
RamInfoDataModel- =
>= >
>> ?
GetRamInfoAsync@ O
(O P
stringP V
computerNameW c
)c d
{ 	
return 
await 
_ramInfoService (
.( ).
"GetHardwareInfoByComputerNameAsync) K
(K L
computerNameL X
)X Y
;Y Z
} 	
public   
async   
Task   
<   
ServiceResultModel   ,
<  , - 
StorageInfoDataModel  - A
>  A B
>  B C
GetStorageInfoAsync  D W
(  W X
string  X ^
computerName  _ k
)  k l
{!! 	
return"" 
await"" 
_storageInfoService"" ,
."", -.
"GetHardwareInfoByComputerNameAsync""- O
(""O P
computerName""P \
)""\ ]
;""] ^
}## 	
}$$ 
}%% Î
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Hardware\RamInfoService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Hardware		- 5
{

 
public 

class 
RamInfoService 
:  !
HardwareInfoService" 5
<5 6
RamInfoDataModel6 F
>F G
,G H
IRamInfoServiceI X
{ 
public 
RamInfoService 
( 
IRamRepository 
ramRepository (
,( )
ILocalRamRepository 
localRamRepository  2
,2 3
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
ramRepository 
, 
localRamRepository  2
,2 3
commandRunner4 A
,A B
resultConverterC R
)R S
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& '
RamInfoDataModel' 7
>7 8
>8 9!
SaveLocalRamInfoAsync: O
(O P
stringP V
ipW Y
)Y Z
{ 	
return &
SaveLocalHardwareInfoAsync -
(- .
ip. 0
)0 1
;1 2
} 	
public 
Task 
< 
ServiceResultModel &
<& '
RamInfoDataModel' 7
>7 8
>8 9)
GetRamInfoByComputerNameAsync: W
(W X
stringX ^
computerName_ k
)k l
{ 	
return .
"GetHardwareInfoByComputerNameAsync 5
(5 6
computerName6 B
)B C
;C D
} 	
} 
}   ß
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Hardware\StorageInfoService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Hardware		- 5
{

 
public 

class 
StorageInfoService #
:$ %
HardwareInfoService& 9
<9 : 
StorageInfoDataModel: N
>N O
,O P
IStorageInfoServiceQ d
{ 
public 
StorageInfoService !
(! "
IStorageRepository 
storageRepository 0
,0 1#
ILocalStorageRepository #"
localStorageRepository$ :
,: ;
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
storageRepository "
," #"
localStorageRepository$ :
,: ;
commandRunner< I
,I J
resultConverterK Z
)Z [
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& ' 
StorageInfoDataModel' ;
>; <
>< =%
SaveLocalStorageInfoAsync> W
(W X
stringX ^
ip_ a
)a b
{ 	
return &
SaveLocalHardwareInfoAsync -
(- .
ip. 0
)0 1
;1 2
} 	
public 
Task 
< 
ServiceResultModel &
<& ' 
StorageInfoDataModel' ;
>; <
>< =-
!GetStorageInfoByComputerNameAsync> _
(_ `
string` f
computerNameg s
)s t
{ 	
return .
"GetHardwareInfoByComputerNameAsync 5
(5 6
computerName6 B
)B C
;C D
} 	
} 
}   ‡
uC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Network\NetworkService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
Network- 4
{ 
public 

class 
NetworkService 
:  !
INetworkService" 1
{ 
public		 
NetworkComputer		 
[		 
]		  &
ListNetworkComputerCommand		! ;
(		; <
)		< =
{

 	
NetworkComputer 
[ 
] 
computersAndIPs -
=. /
new0 3
NetworkComputer4 C
[C D
]D E
{ 
new 
NetworkComputer #
{$ %
Name& *
=+ ,
$str- 6
,6 7
IP8 :
=; <
$str= M
}N O
,O P
} 
; 
return 
computersAndIPs "
;" #
} 	
} 
} î
ÉC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\AdobeReaderInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
Software- 5
{		 
public

 

class

 '
AdobeReaderInstallerService

 ,
:

- .
BaseService

/ :
,

: ;(
IAdobeReaderInstallerService

< X
{ 
private 
readonly )
IInstallAdobeReaderRepository 6)
_installAdobeReaderRepository7 T
;T U
public '
AdobeReaderInstallerService *
(* +
ICommandRunner+ 9
commandRunner: G
,G H
IResultConverterI Y
resultConverterZ i
,i j*
IInstallAdobeReaderRepository	k à*
installAdobeReaderRepository
â •
)
• ¶
: 
base 
( 
commandRunner  
,  !
resultConverter" 1
)1 2
{ 	)
_installAdobeReaderRepository )
=* +(
installAdobeReaderRepository, H
;H I
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;)
_installAdobeReaderRepository< Y
.Y Z
ExecCommandZ e
(e f
newf i+
RepositoryPowerShellParamModel	j à
(
à â
ip
â ã
)
ã å
)
å ç
;
ç é
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} ı
C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\FirefoxInstallerService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementations

 ,
.

, -
Software

- 5
{ 
public 

class #
FirefoxInstallerService (
:) *
BaseService+ 6
,7 8$
IFirefoxInstallerService9 Q
{ 
private 
readonly %
IInstallFirefoxRepository 2%
_installFirefoxRepository3 L
;L M
public #
FirefoxInstallerService &
(& '
ICommandRunner' 5
commandRunner6 C
,C D
IResultConverterE U
resultConverterV e
,e f&
IInstallFirefoxRepository	g Ä&
installFirefoxRepository
Å ô
)
ô ö
:
õ ú
base
ù °
(
° ¢
commandRunner
¢ Ø
,
Ø ∞
resultConverter
± ¿
)
¿ ¡
{ 	%
_installFirefoxRepository %
=& '$
installFirefoxRepository( @
;@ A
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;%
_installFirefoxRepository< U
.U V
ExecCommandV a
(a b
newb e+
RepositoryPowerShellParamModel	f Ñ
(
Ñ Ö
ip
Ö á
)
á à
)
à â
;
â ä
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} ü
ÑC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\GoogleChromeInstallerService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementations

 ,
.

, -
Software

- 5
{ 
public 

class (
GoogleChromeInstallerService -
:. /
BaseService0 ;
,; <)
IGoogleChromeInstallerService= Z
{ 
private 
readonly *
IInstallGoogleChromeRepository 7*
_installGoogleChromeRepository8 V
;V W
public (
GoogleChromeInstallerService +
(+ ,
ICommandRunner, :
commandRunner; H
,H I
IResultConverterJ Z
resultConverter[ j
,j k+
IInstallGoogleChromeRepository	l ä+
installGoogleChromeRepository
ã ®
)
® ©
: 
base 
( 
commandRunner  
,  !
resultConverter" 1
)1 2
{ 	*
_installGoogleChromeRepository *
=+ ,)
installGoogleChromeRepository- J
;J K
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;*
_installGoogleChromeRepository< Z
.Z [
ExecCommand[ f
(f g
newg j+
RepositoryPowerShellParamModel	k â
(
â ä
ip
ä å
)
å ç
)
ç é
;
é è
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} ˛
ÅC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\Office365InstallerService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementations

 ,
.

, -
Software

- 5
{ 
public 

class %
Office365InstallerService *
:+ ,
BaseService- 8
,8 9&
IOffice365InstallerService: T
{ 
private 
readonly '
IInstallOffice365Repository 4'
_installOffice365Repository5 P
;P Q
public %
Office365InstallerService (
(( )
ICommandRunner) 7
commandRunner8 E
,E F
IResultConverterG W
resultConverterX g
,g h(
IInstallOffice365Repository	i Ñ(
installOffice365Repository
Ö ü
)
ü †
: 
base 
( 
commandRunner  
,  !
resultConverter" 1
)1 2
{ 	'
_installOffice365Repository '
=( )&
installOffice365Repository* D
;D E
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;'
_installOffice365Repository< W
.W X
ExecCommandX c
(c d
newd g+
RepositoryPowerShellParamModel	h Ü
(
Ü á
ip
á â
)
â ä
)
ä ã
;
ã å
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} Ë
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\SoftwareService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
Software- 5
{ 
public 

class 
SoftwareService  
:! "
ISoftwareService# 3
{ 
private 
readonly 

Dictionary #
<# $
string$ *
,* +%
ISoftwareInstallerService, E
>E F
_installerServicesG Y
;Y Z
public

 
SoftwareService

 
(

 

Dictionary

 )
<

) *
string

* 0
,

0 1%
ISoftwareInstallerService

2 K
>

K L
installerServices

M ^
)

^ _
{ 	
_installerServices 
=  
installerServices! 2
;2 3
} 	
public 
async 
Task 
InstallSoftware )
() *
string* 0
ip1 3
,3 4
string5 ;
softwareName< H
)H I
{ 	
if 
( 
_installerServices "
." #
TryGetValue# .
(. /
softwareName/ ;
,; <
out= @%
ISoftwareInstallerServiceA Z
?Z [
installerService\ l
)l m
)m n
{ 
await 
installerService &
.& '"
InstallSoftwareCommand' =
(= >
ip> @
,@ A
softwareNameB N
)N O
;O P
} 
else 
{ 
throw 
new 
ArgumentException +
(+ ,
$", .
$str. O
{O P
softwareNameP \
}\ ]
"] ^
,^ _
nameof` f
(f g
softwareNameg s
)s t
)t u
;u v
} 
} 	
} 
} π
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\VlcInstallerService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Software		- 5
{

 
public 

class 
VlcInstallerService $
:% &
BaseService' 2
,2 3 
IVlcInstallerService4 H
{ 
private 
readonly !
IInstallVlcRepository .!
_installVlcRepository/ D
;D E
public 
VlcInstallerService "
(" #
ICommandRunner# 1
commandRunner2 ?
,? @
IResultConverterA Q
resultConverterR a
,a b!
IInstallVlcRepositoryc x!
installVlcRepository	y ç
)
ç é
: 	
base
 
( 
commandRunner 
, 
resultConverter -
)- .
{ 	!
_installVlcRepository !
=" # 
installVlcRepository$ 8
;8 9
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;!
_installVlcRepository< Q
.Q R
ExecCommandR ]
(] ^
new^ a+
RepositoryPowerShellParamModel	b Ä
(
Ä Å
ip
Å É
)
É Ñ
)
Ñ Ö
;
Ö Ü
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} ⁄
~C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Software\WinrarInstallerService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementations		 ,
.		, -
Software		- 5
{

 
public 

class "
WinrarInstallerService '
:( )
BaseService* 5
,5 6#
IWinrarInstallerService7 N
{ 
private 
readonly $
IInstallWinrarRepository 1$
_installWinrarRepository2 J
;J K
public "
WinrarInstallerService %
(% &
ICommandRunner& 4
commandRunner5 B
,B C
IResultConverterD T
resultConverterU d
,d e$
IInstallWinrarRepositoryf ~$
installWinrarRepository	 ñ
)
ñ ó
: 
base 
( 
commandRunner  
,  !
resultConverter" 1
)1 2
{ 	$
_installWinrarRepository $
=% &#
installWinrarRepository' >
;> ?
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
object- 3
>3 4
>4 5"
InstallSoftwareCommand6 L
(L M
stringM S
ipT V
,V W
stringX ^
softwareName_ k
)k l
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
	resultRep* 3
=4 5
await6 ;$
_installWinrarRepository< T
.T U
ExecCommandU `
(` a
newa d+
RepositoryPowerShellParamModel	e É
(
É Ñ
ip
Ñ Ü
)
Ü á
)
á à
;
à â
return 

RunCommand 
( 
ConvertResult +
(+ ,
	resultRep, 5
)5 6
)6 7
;7 8
} 	
} 
} «
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\ChocolateyInfoService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementation

 +
.

+ ,
System

, 2
{ 
public 

class !
ChocolateyInfoService &
:' (
SystemInfoService) :
<: ;#
ChocolateyInfoDataModel; R
>R S
,S T"
IChocolateyInfoServiceU k
{ 
public !
ChocolateyInfoService $
($ %
ISystemRepository 
< #
ChocolateyInfoDataModel 5
>5 6 
chocolateyRepository7 K
,K L"
ILocalSystemRepository "
<" ##
ChocolateyInfoDataModel# :
>: ;%
localChocolateyRepository< U
,U V
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
(  
chocolateyRepository %
,% &%
localChocolateyRepository' @
,@ A
commandRunnerB O
,O P
resultConverterQ `
)` a
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& '#
ChocolateyInfoDataModel' >
>> ?
>? @(
SaveLocalChocolateyInfoAsyncA ]
(] ^
string^ d
ipe g
)g h
{ 	
return $
SaveLocalSystemInfoAsync +
(+ ,
ip, .
). /
;/ 0
} 	
public 
Task 
< 
ServiceResultModel &
<& '#
ChocolateyInfoDataModel' >
>> ?
>? @0
$GetChocolateyInfoByComputerNameAsyncA e
(e f
stringf l
computerNamem y
)y z
{ 	
return ,
 GetSystemInfoByComputerNameAsync 3
(3 4
computerName4 @
)@ A
;A B
} 	
}   
}!! ≥
ÇC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\InstalledProgramsInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementation +
.+ ,
System, 2
{ 
public 

class (
InstalledProgramsInfoService -
:. /
SystemInfoService0 A
<A B*
InstalledProgramsResponseModelB `
>` a
,a b*
IInstalledProgramsInfoService	c Ä
{ 
public (
InstalledProgramsInfoService +
(+ ,(
IInstalledProgramsRepository ('
installedProgramsRepository) D
,D E-
!ILocalInstalledProgramsRepository -,
 localinstalledProgramsRepository. N
,N O
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( '
installedProgramsRepository ,
,, -,
 localinstalledProgramsRepository. N
,N O
commandRunnerP ]
,] ^
resultConverter_ n
)n o
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& '*
InstalledProgramsResponseModel' E
>E F
>F G/
#SaveLocalInstalledProgramsInfoAsyncH k
(k l
stringl r
ips u
)u v
{ 	
return $
SaveLocalSystemInfoAsync +
(+ ,
ip, .
). /
;/ 0
} 	
public 
Task 
< 
ServiceResultModel &
<& '*
InstalledProgramsResponseModel' E
>E F
>F G3
'GetInstalledProgramsByComputerNameAsyncH o
(o p
stringp v
computerName	w É
)
É Ñ
{ 	
return ,
 GetSystemInfoByComputerNameAsync 3
(3 4
computerName4 @
)@ A
;A B
}   	
}!! 
}"" ∏
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\OsVersionInfoService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementation

 +
.

+ ,
System

, 2
{ 
public 

class  
OsVersionInfoService %
:& '
SystemInfoService( 9
<9 :"
OSVersionInfoDataModel: P
>P Q
,Q R!
IOsVersionInfoServiceS h
{ 
public  
OsVersionInfoService #
(# $
ISystemRepository 
< "
OSVersionInfoDataModel 4
>4 5
osVersionRepository6 I
,I J"
ILocalSystemRepository "
<" #"
OSVersionInfoDataModel# 9
>9 :$
localOsVersionRepository; S
,S T
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
osVersionRepository $
,$ %$
localOsVersionRepository& >
,> ?
commandRunner@ M
,M N
resultConverterO ^
)^ _
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& '"
OSVersionInfoDataModel' =
>= >
>> ?'
SaveLocalOsVersionInfoAsync@ [
([ \
string\ b
ipc e
)e f
{ 	
return $
SaveLocalSystemInfoAsync +
(+ ,
ip, .
). /
;/ 0
} 	
public 
Task 
< 
ServiceResultModel &
<& '"
OSVersionInfoDataModel' =
>= >
>> ?/
#GetOsVersionInfoByComputerNameAsync@ c
(c d
stringd j
computerNamek w
)w x
{ 	
return ,
 GetSystemInfoByComputerNameAsync 3
(3 4
computerName4 @
)@ A
;A B
} 	
}   
}!! Í$
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\SystemCommandService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 
Implementations ,
., -
System- 3
{ 
public 

class  
SystemCommandService %
:& '!
ISystemCommandService( =
{		 
private

 
readonly

 !
IShutdownPcRepository

 .!
_shutdownPcRepository

/ D
;

D E
private 
readonly  
IRestartPcRepository - 
_restartPcRepository. B
;B C
public  
SystemCommandService #
(# $!
IShutdownPcRepository ! 
shutdownPcRepository" 6
,6 7 
IRestartPcRepository  
restartPcRepository! 4
) 	
{ 	!
_shutdownPcRepository !
=" # 
shutdownPcRepository$ 8
;8 9 
_restartPcRepository  
=! "
restartPcRepository# 6
;6 7
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
string- 3
>3 4
>4 5
ShutdownPcCommand6 G
(G H
stringH N
ipO Q
)Q R
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
repositoryResult* :
=; <
await= B!
_shutdownPcRepositoryC X
.X Y
ExecCommandY d
(d e
newe h+
RepositoryPowerShellParamModel	i á
(
á à
ip
à ä
)
ä ã
)
ã å
;
å ç
return 
ConvertResult  
(  !
repositoryResult! 1
)1 2
;2 3
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
string- 3
>3 4
>4 5
RestartPcCommand6 F
(F G
stringG M
ipN P
)P Q
{ 	!
RepositoryResultModel !
<! "
string" (
>( )
repositoryResult* :
=; <
await= B 
_restartPcRepositoryC W
.W X
ExecCommandX c
(c d
newd g+
RepositoryPowerShellParamModel	h Ü
(
Ü á
ip
á â
)
â ä
)
ä ã
;
ã å
return 
ConvertResult  
(  !
repositoryResult! 1
)1 2
;2 3
}   	
private"" 
ServiceResultModel"" "
<""" #
string""# )
>"") *
ConvertResult""+ 8
(""8 9!
RepositoryResultModel""9 N
<""N O
string""O U
>""U V
repositoryResult""W g
)""g h
{## 	
if$$ 
($$ 
repositoryResult$$  
.$$  !
SuccessResult$$! .
!=$$/ 1
null$$2 6
)$$6 7
{%% 
return&& 
new&& 
ServiceResultModel&& -
<&&- .
string&&. 4
>&&4 5
(&&5 6
success'' 
:'' 
new''   
SuccessServiceResult''! 5
<''5 6
string''6 <
>''< =
(''= >
repositoryResult''> N
.''N O
SuccessResult''O \
.''\ ]
Result''] c
,''c d
DateTime''e m
.''m n
UtcNow''n t
,''t u
repositoryResult	''v Ü
.
''Ü á
Ip
''á â
)
''â ä
)(( 
;(( 
})) 
else** 
{++ 
return,, 
repositoryResult,, '
.,,' (
ErrorResult,,( 3
!=,,4 6
null,,7 ;
?-- 
new-- 
ServiceResultModel-- ,
<--, -
string--- 3
>--3 4
(--4 5
error..$ )
:..) *
new..+ .
ErrorServiceResult../ A
(..A B
repositoryResult..B R
...R S
ErrorResult..S ^
...^ _
Message.._ f
,..f g
DateTime..h p
...p q
UtcNow..q w
,..w x
repositoryResult	..y â
.
..â ä
Ip
..ä å
)
..å ç
)//  !
:00 
throw00 
new00 %
InvalidOperationException00  9
(009 :
$str	00: Ö
)
00Ö Ü
;
00Ü á
}11 
}22 	
}33 
}44 ·/
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\SystemInfoService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementations

 ,
.

, -
System

- 3
{ 
public 

abstract 
class 
SystemInfoService +
<+ ,
T, -
>- .
:/ 0
BaseService1 <
where= B
TC D
:E F
BaseInfoDataModelG X
{ 
	protected 
readonly 
ISystemRepository ,
<, -
T- .
>. /
_systemRepository0 A
;A B
	protected 
readonly "
ILocalSystemRepository 1
<1 2
T2 3
>3 4"
_localSystemRepository5 K
;K L
public 
SystemInfoService  
(  !
ISystemRepository! 2
<2 3
T3 4
>4 5
systemRepository6 F
,F G"
ILocalSystemRepositoryH ^
<^ _
T_ `
>` a!
localSystemRepositoryb w
,w x
ICommandRunner	y á
commandRunner
à ï
,
ï ñ
IResultConverter
ó ß
resultConverter
® ∑
)
∑ ∏
:
π ∫
base
ª ø
(
ø ¿
commandRunner
¿ Õ
,
Õ Œ
resultConverter
œ ﬁ
)
ﬁ ﬂ
{ 	
_systemRepository 
= 
systemRepository  0
;0 1"
_localSystemRepository "
=# $!
localSystemRepository% :
;: ;
} 	
public 
async 
Task 
< 
ServiceResultModel ,
<, -
T- .
>. /
>/ 0$
SaveLocalSystemInfoAsync1 I
(I J
stringJ P
ipQ S
)S T
{ 	!
RepositoryResultModel !
<! "
T" #
># $!
localSystemInfoResult% :
=; <
await= B"
_localSystemRepositoryC Y
.Y Z
ExecCommandZ e
(e f
newf i+
RepositoryPowerShellParamModel	j à
(
à â
ip
â ã
)
ã å
)
å ç
;
ç é
if 
( !
localSystemInfoResult %
.% &
SuccessResult& 3
!=4 6
null7 ;
); <
{ 
await 
_systemRepository '
.' (
InsertAsync( 3
(3 4!
localSystemInfoResult4 I
.I J
SuccessResultJ W
.W X
ResultX ^
)^ _
;_ ` 
SuccessServiceResult $
<$ %
T% &
>& '
successResult( 5
=6 7
new8 ; 
SuccessServiceResult< P
<P Q
TQ R
>R S
(S T!
localSystemInfoResultT i
.i j
SuccessResultj w
.w x
Resultx ~
,~ 
DateTime
Ä à
.
à â
UtcNow
â è
,
è ê
ip
ë ì
)
ì î
;
î ï
return 
new 
ServiceResultModel -
<- .
T. /
>/ 0
(0 1
successResult1 >
)> ?
;? @
} 
else 
if 
( !
localSystemInfoResult *
.* +
ErrorResult+ 6
!=7 9
null: >
)> ?
{   
ErrorServiceResult!! "
errorResult!!# .
=!!/ 0
new!!1 4
ErrorServiceResult!!5 G
(!!G H!
localSystemInfoResult!!H ]
.!!] ^
ErrorResult!!^ i
.!!i j
	Exception!!j s
.!!s t
Message!!t {
,!!{ |
DateTime	!!} Ö
.
!!Ö Ü
UtcNow
!!Ü å
,
!!å ç
ip
!!é ê
)
!!ê ë
;
!!ë í
return"" 
new"" 
ServiceResultModel"" -
<""- .
T"". /
>""/ 0
(""0 1
error""1 6
:""6 7
errorResult""8 C
)""C D
;""D E
}## 
else$$ 
{%% 
ErrorServiceResult&& "
errorResult&&# .
=&&/ 0
new&&1 4
ErrorServiceResult&&5 G
(&&G H
$str&&H j
,&&j k
DateTime&&l t
.&&t u
UtcNow&&u {
,&&{ |
ip&&} 
)	&& Ä
;
&&Ä Å
return'' 
new'' 
ServiceResultModel'' -
<''- .
T''. /
>''/ 0
(''0 1
error''1 6
:''6 7
errorResult''8 C
)''C D
;''D E
}(( 
})) 	
public** 
async** 
Task** 
<** 
ServiceResultModel** ,
<**, -
T**- .
>**. /
>**/ 0,
 GetSystemInfoByComputerNameAsync**1 Q
(**Q R
string**R X
computerName**Y e
)**e f
{++ 	
T,, 

systemInfo,, 
=,, 
await,,  
_systemRepository,,! 2
.,,2 3"
GetByComputerNameAsync,,3 I
(,,I J
computerName,,J V
),,V W
;,,W X 
SuccessServiceResult--  
<--  !
T--! "
>--" #
successResult--$ 1
=--2 3
new--4 7 
SuccessServiceResult--8 L
<--L M
T--M N
>--N O
(--O P

systemInfo--P Z
,--Z [
DateTime--\ d
.--d e
UtcNow--e k
,--k l
computerName--m y
)--y z
;--z {
return.. 
new.. 
ServiceResultModel.. )
<..) *
T..* +
>..+ ,
(.., -
successResult..- :
)..: ;
;..; <
}// 	
}00 
}11 î 
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\SystemService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementation		 +
.		+ ,
System		, 2
{

 
public 

class 
SystemService 
:  
BaseService! ,
,, -
ISystemService. <
{ 
private 
readonly "
IChocolateyInfoService /"
_chocolateyInfoService0 F
;F G
private 
readonly 
IUsersInfoService *
_usersInfoService+ <
;< =
private 
readonly !
IOsVersionInfoService .!
_osVersionInfoService/ D
;D E
private 
readonly )
IInstalledProgramsInfoService 6)
_installedProgramsInfoService7 T
;T U
public 
SystemService 
( "
IChocolateyInfoService "!
chocolateyInfoService# 8
,8 9
IUsersInfoService 
usersInfoService .
,. /!
IOsVersionInfoService ! 
osVersionInfoService" 6
,6 7)
IInstalledProgramsInfoService )(
installedProgramsInfoService* F
,F G
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
commandRunner 
, 
resultConverter  /
)/ 0
{ 	"
_chocolateyInfoService "
=# $!
chocolateyInfoService% :
;: ;
_usersInfoService 
= 
usersInfoService  0
;0 1!
_osVersionInfoService !
=" # 
osVersionInfoService$ 8
;8 9)
_installedProgramsInfoService )
=* +(
installedProgramsInfoService, H
;H I
} 	
public!! 
Task!! 
<!! 
ServiceResultModel!! &
<!!& '#
ChocolateyInfoDataModel!!' >
>!!> ?
>!!? @"
GetChocolateyInfoAsync!!A W
(!!W X
string!!X ^
computerName!!_ k
)!!k l
{"" 	
return## "
_chocolateyInfoService## )
.##) *,
 GetSystemInfoByComputerNameAsync##* J
(##J K
computerName##K W
)##W X
;##X Y
}$$ 	
public&& 
Task&& 
<&& 
ServiceResultModel&& &
<&&& '
UsersInfoDataModel&&' 9
>&&9 :
>&&: ;
GetUsersInfoAsync&&< M
(&&M N
string&&N T
computerName&&U a
)&&a b
{'' 	
return(( 
_usersInfoService(( $
.(($ %,
 GetSystemInfoByComputerNameAsync((% E
(((E F
computerName((F R
)((R S
;((S T
})) 	
public++ 
Task++ 
<++ 
ServiceResultModel++ &
<++& '"
OSVersionInfoDataModel++' =
>++= >
>++> ?!
GetOsVersionInfoAsync++@ U
(++U V
string++V \
computerName++] i
)++i j
{,, 	
return-- !
_osVersionInfoService-- (
.--( ),
 GetSystemInfoByComputerNameAsync--) I
(--I J
computerName--J V
)--V W
;--W X
}.. 	
public00 
Task00 
<00 
ServiceResultModel00 &
<00& '*
InstalledProgramsResponseModel00' E
>00E F
>00F G)
GetInstalledProgramsInfoAsync00H e
(00e f
string00f l
computerName00m y
)00y z
{11 	
return22 )
_installedProgramsInfoService22 0
.220 1,
 GetSystemInfoByComputerNameAsync221 Q
(22Q R
computerName22R ^
)22^ _
;22_ `
}33 	
}44 
}55 ¸
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\System\UsersInfoService.cs
	namespace

 	
	NetMaster


 
.

 
Services

 
.

 
Implementation

 +
.

+ ,
System

, 2
{ 
public 

class 
UsersInfoService !
:" #
SystemInfoService$ 5
<5 6
UsersInfoDataModel6 H
>H I
,I J
IUsersInfoServiceK \
{ 
public 
UsersInfoService 
(  
ISystemRepository 
< 
UsersInfoDataModel 0
>0 1
usersRepository2 A
,A B"
ILocalSystemRepository "
<" #
UsersInfoDataModel# 5
>5 6 
localUsersRepository7 K
,K L
ICommandRunner 
commandRunner (
,( )
IResultConverter 
resultConverter ,
) 	
:
 
base 
( 
usersRepository  
,  ! 
localUsersRepository" 6
,6 7
commandRunner8 E
,E F
resultConverterG V
)V W
{ 	
} 	
public 
Task 
< 
ServiceResultModel &
<& '
UsersInfoDataModel' 9
>9 :
>: ;#
SaveLocalUsersInfoAsync< S
(S T
stringT Z
ip[ ]
)] ^
{ 	
return $
SaveLocalSystemInfoAsync +
(+ ,
ip, .
). /
;/ 0
} 	
public 
Task 
< 
ServiceResultModel &
<& '
UsersInfoDataModel' 9
>9 :
>: ;+
GetUsersInfoByComputerNameAsync< [
([ \
string\ b
computerNamec o
)o p
{ 	
return ,
 GetSystemInfoByComputerNameAsync 3
(3 4
computerName4 @
)@ A
;A B
} 	
}   
}!! “.
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Implementations\Upload\UploadService.cs
	namespace		 	
	NetMaster		
 
.		 
Services		 
.		 
Implementation		 +
.		+ ,
Upload		, 2
{

 
public 

class 
UploadService 
:  
BaseService! ,
,, -
IUploadService. <
{ 
private 
readonly !
IUploadFileRepository .!
_uploadFileRepository/ D
;D E
public 
UploadService 
( 
ICommandRunner +
commandRunner, 9
,9 :
IResultConverter; K
resultConverterL [
,[ \!
IUploadFileRepository] r!
uploadFileRepository	s á
)
á à
: 
base 
( 
commandRunner  
,  !
resultConverter" 1
)1 2
{ 	!
_uploadFileRepository !
=" # 
uploadFileRepository$ 8
;8 9
} 	
public 
ServiceResultModel !
<! "
object" (
>( )
ValidateFile* 6
(6 7
	IFormFile7 @
fileA E
)E F
{ 	
if 
( 
file 
== 
null 
|| 
file  $
.$ %
Length% +
==, .
$num/ 0
)0 1
{ 
return 
new 
ServiceResultModel -
<- .
object. 4
>4 5
(5 6
error 
: 
new 
ErrorServiceResult 1
(1 2
$str2 O
,O P
DateTimeQ Y
.Y Z
NowZ ]
,] ^
Environment_ j
.j k
MachineNamek v
)v w
) 
; 
} 
return 
new 
ServiceResultModel )
<) *
object* 0
>0 1
(1 2
success 
: 
new  
SuccessServiceResult 1
<1 2
object2 8
>8 9
(9 :
null: >
,> ?
DateTime@ H
.H I
NowI L
,L M
EnvironmentN Y
.Y Z
MachineNameZ e
)e f
)   
;   
}!! 	
public## 
ServiceResultModel## !
<##! "
UploadResult##" .
>##. /

UploadFile##0 :
(##: ;
	IFormFile##; D
file##E I
)##I J
{$$ 	
ServiceResultModel%% 
<%% 
object%% %
>%%% &
validationResult%%' 7
=%%8 9
ValidateFile%%: F
(%%F G
file%%G K
)%%K L
;%%L M
if&& 
(&& 
!&& 
validationResult&& !
.&&! "
	IsSuccess&&" +
)&&+ ,
{'' 
return(( 
new(( 
ServiceResultModel(( -
<((- .
UploadResult((. :
>((: ;
(((; <
error((< A
:((A B
validationResult((C S
.((S T
ErrorResult((T _
)((_ `
;((` a
})) 
string++ 
destinationFolder++ $
=++% &
$str++' 0
;++0 1
byte,, 
[,, 
],, 
fileData,, 
=,, 
ReadFileData,, *
(,,* +
file,,+ /
),,/ 0
;,,0 1!
RepositoryResultModel.. !
<..! "
UploadResult.." .
>... /
	resultRep..0 9
=..: ;!
_uploadFileRepository..< Q
...Q R

UploadFile..R \
(..\ ]
file..] a
...a b
FileName..b j
,..j k
fileData..l t
,..t u
destinationFolder	..v á
)
..á à
;
..à â
if// 
(// 
	resultRep// 
.// 
Success// !
)//! "
{00 
return11 
new11 
ServiceResultModel11 -
<11- .
UploadResult11. :
>11: ;
(11; <
success22 
:22 
new22   
SuccessServiceResult22! 5
<225 6
UploadResult226 B
>22B C
(22C D
	resultRep22D M
.22M N
Data22N R
,22R S
DateTime22T \
.22\ ]
Now22] `
,22` a
Environment22b m
.22m n
MachineName22n y
)22y z
)33 
;33 
}44 
else55 
{66 
return77 
new77 
ServiceResultModel77 -
<77- .
UploadResult77. :
>77: ;
(77; <
error88 
:88 
new88 
ErrorServiceResult88 1
(881 2
	resultRep882 ;
.88; <
ErrorResult88< G
.88G H
Message88H O
,88O P
DateTime88Q Y
.88Y Z
Now88Z ]
,88] ^
Environment88_ j
.88j k
MachineName88k v
)88v w
)99 
;99 
}:: 
};; 	
private@@ 
byte@@ 
[@@ 
]@@ 
ReadFileData@@ #
(@@# $
	IFormFile@@$ -
file@@. 2
)@@2 3
{AA 	
usingBB 
MemoryStreamBB 
memoryStreamBB +
=BB, -
newBB. 1
(BB1 2
)BB2 3
;BB3 4
fileCC 
.CC 
CopyToCC 
(CC 
memoryStreamCC $
)CC$ %
;CC% &
returnDD 
memoryStreamDD 
.DD  
ToArrayDD  '
(DD' (
)DD( )
;DD) *
}EE 	
}FF 
}GG ¢
kC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Base\IBaseService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Base( ,
{ 
[ 
AutoDI 
] 
public 

	interface 
IBaseService !
{		 
ServiceResultModel

 
<

 
T

 
>

 

RunCommand

 (
<

( )
T

) *
>

* +
(

+ ,!
RepositoryResultModel

, A
<

A B
T

B C
>

C D
result

E K
)

K L
where

M R
T

S T
:

U V
class

W \
;

\ ]!
RepositoryResultModel 
< 
object $
>$ %
ConvertResult& 3
(3 4!
RepositoryResultModel4 I
<I J
stringJ P
>P Q
resultR X
)X Y
;Y Z
} 
} ô
mC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Base\ICommandRunner.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Base( ,
{ 
[ 
AutoDI 
] 
public 

	interface 
ICommandRunner #
{		 
ServiceResultModel

 
<

 
T

 
>

 
Run

 !
<

! "
T

" #
>

# $
(

$ %!
RepositoryResultModel

% :
<

: ;
T

; <
>

< =
result

> D
)

D E
where

F K
T

L M
:

N O
class

P U
;

U V
} 
} ∂
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Base\IComputerInfoBackgroundService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
BackgroundServices( :
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
 *
IComputerInfoBackgroundService

 3
{ 
Task 
ExecuteAsync 
( 
CancellationToken +
stoppingToken, 9
)9 :
;: ;
Task ,
 CollectAndStoreComputerInfoAsync -
(- .
). /
;/ 0
( 	
ISystemService	 
SystemService %
,% &
IRamInfoService	 
RamInfoService '
,' (
IStorageInfoService	 
StorageInfoService /
,/ 0"
IChocolateyInfoService	 !
ChocolateyInfoService  5
,5 6)
IInstalledProgramsInfoService	 &(
InstalledProgramsInfoService' C
,C D!
IOsVersionInfoService	  
OsVersionInfoService 3
,3 4
IUsersInfoService	 
UserInfoService *
) 	
GetRequiredServices
 
( 
IServiceProvider .
serviceProvider/ >
)> ?
;? @
} 
} Ω
oC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Base\IResultConverter.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Base( ,
{ 
[ 
AutoDI 
] 
public 

	interface 
IResultConverter %
{		 !
RepositoryResultModel

 
<

 
object

 $
>

$ %
Convert

& -
(

- .!
RepositoryResultModel

. C
<

C D
string

D J
>

J K
result

L R
)

R S
;

S T
} 
} º
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Hardware\IHardwareInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Hardware( 0
{ 
[ 
AutoDI 
] 
public 

	interface  
IHardwareInfoService )
<) *
T* +
>+ ,
where- 2
T3 4
:5 6
class7 <
{		 
Task

 
<

 
ServiceResultModel

 
<

  
T

  !
>

! "
>

" #&
SaveLocalHardwareInfoAsync

$ >
(

> ?
string

? E
ip

F H
)

H I
;

I J
Task 
< 
ServiceResultModel 
<  
T  !
>! "
>" #.
"GetHardwareInfoByComputerNameAsync$ F
(F G
stringG M
computerNameN Z
)Z [
;[ \
} 
} ’
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Hardware\IHardwareService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Hardware( 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IHardwareService		 %
{

 
Task 
< 
ServiceResultModel 
<  
RamInfoDataModel  0
>0 1
>1 2
GetRamInfoAsync3 B
(B C
stringC I
computerNameJ V
)V W
;W X
Task 
< 
ServiceResultModel 
<   
StorageInfoDataModel  4
>4 5
>5 6
GetStorageInfoAsync7 J
(J K
stringK Q
computerNameR ^
)^ _
;_ `
} 
} ¬
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Hardware\IRamInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Hardware( 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IRamInfoService		 $
:		% & 
IHardwareInfoService		' ;
<		; <
RamInfoDataModel		< L
>		L M
{

 
Task 
< 
ServiceResultModel 
<  
RamInfoDataModel  0
>0 1
>1 2!
SaveLocalRamInfoAsync3 H
(H I
stringI O
ipP R
)R S
;S T
Task 
< 
ServiceResultModel 
<  
RamInfoDataModel  0
>0 1
>1 2)
GetRamInfoByComputerNameAsync3 P
(P Q
stringQ W
computerNameX d
)d e
;e f
} 
} ﬁ
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Hardware\IStorageInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Hardware( 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IStorageInfoService		 (
:		) * 
IHardwareInfoService		+ ?
<		? @ 
StorageInfoDataModel		@ T
>		T U
{

 
Task 
< 
ServiceResultModel 
<   
StorageInfoDataModel  4
>4 5
>5 6%
SaveLocalStorageInfoAsync7 P
(P Q
stringQ W
ipX Z
)Z [
;[ \
Task 
< 
ServiceResultModel 
<   
StorageInfoDataModel  4
>4 5
>5 6-
!GetStorageInfoByComputerNameAsync7 X
(X Y
stringY _
computerName` l
)l m
;m n
} 
} —
qC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Network\INetworkService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Network( /
{ 
[ 
AutoDI 
] 
public 

	interface 
INetworkService $
{		 
NetworkComputer

 
[

 
]

 &
ListNetworkComputerCommand

 4
(

4 5
)

5 6
;

6 7
} 
} ì
C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IAdobeReaderInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public		 

	interface		 (
IAdobeReaderInstallerService		 1
:		2 3%
ISoftwareInstallerService		4 M
{

 
} 
} ã
{C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IFirefoxInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface $
IFirefoxInstallerService -
:. /%
ISoftwareInstallerService0 I
{		 
}

 
} ñ
ÄC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IGoogleChromeInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface )
IGoogleChromeInstallerService 2
:3 4%
ISoftwareInstallerService5 N
{		 
}

 
} è
}C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IOffice365InstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface &
IOffice365InstallerService /
:0 1%
ISoftwareInstallerService2 K
{		 
}

 
} ã
|C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\ISoftwareInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface %
ISoftwareInstallerService .
{		 
Task

 
<

 
ServiceResultModel

 
<

  
object

  &
>

& '
>

' ("
InstallSoftwareCommand

) ?
(

? @
string

@ F
ip

G I
,

I J
string

K Q
softwareName

R ^
)

^ _
;

_ `
} 
} Ç
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\ISoftwareService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface 
ISoftwareService %
{ 
Task 
InstallSoftware 
( 
string #
ip$ &
,& '
string( .
softwareName/ ;
); <
;< =
}		 
} É
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IVlcInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface  
IVlcInstallerService )
:* +%
ISoftwareInstallerService, E
{		 
}

 
} â
zC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Software\IWinrarInstallerService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
Software( 0
{ 
[ 
AutoDI 
] 
public 

	interface #
IWinrarInstallerService ,
:- .%
ISoftwareInstallerService/ H
{		 
}

 
} Ì
wC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\IChocolateyInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 "
IChocolateyInfoService		 +
:		, -
ISystemInfoService		. @
<		@ A#
ChocolateyInfoDataModel		A X
>		X Y
{

 
Task 
< 
ServiceResultModel 
<  #
ChocolateyInfoDataModel  7
>7 8
>8 9(
SaveLocalChocolateyInfoAsync: V
(V W
stringW ]
ip^ `
)` a
;a b
Task 
< 
ServiceResultModel 
<  #
ChocolateyInfoDataModel  7
>7 8
>8 90
$GetChocolateyInfoByComputerNameAsync: ^
(^ _
string_ e
computerNamef r
)r s
;s t
} 
} ö	
~C:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\IInstalledProgramsInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 )
IInstalledProgramsInfoService		 2
:		3 4
ISystemInfoService		5 G
<		G H*
InstalledProgramsResponseModel		H f
>		f g
{

 
Task 
< 
ServiceResultModel 
<  *
InstalledProgramsResponseModel  >
>> ?
>? @/
#SaveLocalInstalledProgramsInfoAsyncA d
(d e
stringe k
ipl n
)n o
;o p
Task 
< 
ServiceResultModel 
<  *
InstalledProgramsResponseModel  >
>> ?
>? @3
'GetInstalledProgramsByComputerNameAsyncA h
(h i
stringi o
computerNamep |
)| }
;} ~
} 
} Ê
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\IOsVersionInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 !
IOsVersionInfoService		 *
:		+ ,
ISystemInfoService		- ?
<		? @"
OSVersionInfoDataModel		@ V
>		V W
{

 
Task 
< 
ServiceResultModel 
<  "
OSVersionInfoDataModel  6
>6 7
>7 8'
SaveLocalOsVersionInfoAsync9 T
(T U
stringU [
ip\ ^
)^ _
;_ `
Task 
< 
ServiceResultModel 
<  "
OSVersionInfoDataModel  6
>6 7
>7 8/
#GetOsVersionInfoByComputerNameAsync9 \
(\ ]
string] c
computerNamed p
)p q
;q r
} 
} Æ
vC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\ISystemCommandService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
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
ISystemCommandService

 *
{ 
Task 
< 
ServiceResultModel 
<  
string  &
>& '
>' (
ShutdownPcCommand) :
(: ;
string; A
ipB D
)D E
;E F
Task 
< 
ServiceResultModel 
<  
string  &
>& '
>' (
RestartPcCommand) 9
(9 :
string: @
ipA C
)C D
;D E
} 
} ∞
sC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\ISystemInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public 

	interface 
ISystemInfoService '
<' (
T( )
>) *
where+ 0
T1 2
:3 4
class5 :
{		 
Task

 
<

 
ServiceResultModel

 
<

  
T

  !
>

! "
>

" #$
SaveLocalSystemInfoAsync

$ <
(

< =
string

= C
ip

D F
)

F G
;

G H
Task 
< 
ServiceResultModel 
<  
T  !
>! "
>" #,
 GetSystemInfoByComputerNameAsync$ D
(D E
stringE K
computerNameL X
)X Y
;Y Z
} 
} á
oC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\ISystemService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 
ISystemService		 #
{

 
Task 
< 
ServiceResultModel 
<  #
ChocolateyInfoDataModel  7
>7 8
>8 9"
GetChocolateyInfoAsync: P
(P Q
stringQ W
computerNameX d
)d e
;e f
Task 
< 
ServiceResultModel 
<  *
InstalledProgramsResponseModel  >
>> ?
>? @)
GetInstalledProgramsInfoAsyncA ^
(^ _
string_ e
computerNamef r
)r s
;s t
Task 
< 
ServiceResultModel 
<  "
OSVersionInfoDataModel  6
>6 7
>7 8!
GetOsVersionInfoAsync9 N
(N O
stringO U
computerNameV b
)b c
;c d
Task 
< 
ServiceResultModel 
<  
UsersInfoDataModel  2
>2 3
>3 4
GetUsersInfoAsync5 F
(F G
stringG M
computerNameN Z
)Z [
;[ \
} 
}  
rC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\System\IUsersInfoService.cs
	namespace 	
	NetMaster
 
. 
Services 
. 

Interfaces '
.' (
System( .
{ 
[ 
AutoDI 
] 
public		 

	interface		 
IUsersInfoService		 &
:		' (
ISystemInfoService		) ;
<		; <
UsersInfoDataModel		< N
>		N O
{

 
Task 
< 
ServiceResultModel 
<  
UsersInfoDataModel  2
>2 3
>3 4#
SaveLocalUsersInfoAsync5 L
(L M
stringM S
ipT V
)V W
;W X
Task 
< 
ServiceResultModel 
<  
UsersInfoDataModel  2
>2 3
>3 4+
GetUsersInfoByComputerNameAsync5 T
(T U
stringU [
computerName\ h
)h i
;i j
} 
} ≈
oC:\Users\hdmni\source\repos\Higor-Matos\NetMaster\NetMaster.Services.csproj\Interfaces\Upload\IUploadService.cs
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
	interface		 
IUploadService		 #
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
ServiceResultModel 
< 
UploadResult '
>' (

UploadFile) 3
(3 4
	IFormFile4 =
file> B
)B C
;C D
} 
} 