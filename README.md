# AspIdentity.WebApi
Building Simple Membership System using ASP.NET Identity 2.1, ASP.NET Web API

Basic instruction.
I am using Code first entity

to enable it please open Package manager console and run this script

	
1. enable-migrations
2. add-migration InitialCreate
3. update-database

This is a OAuth user management with authentication and
authorization with refresh token. feel free to use this to your application.

--- Update 2015-09-23----
App hosting to apphurber
http://aspnetidentitywebapi.apphb.com

To check use rest client (more update on API endpoint will comming soon)

---- Generate Machine key---------------------------------------------------------------------------------------------
you need to generate machine key and put that to webconfig.
this is asample key not provide to  your system rather generate new and do not use 3rd party. use powershall
this is sample using here
    <machineKey validationKey="A970D0E3C36AA17C43C5DB225C778B3392BAED4D7089C6AAF76E3D4243E64FD797BD17611868E85D2E4E1C8B6F1FB684B0C8DBA0C39E20284B7FCA73E0927B20"
            decryptionKey="88274072DD5AC1FB6CED8281B34CDC6E79DD7223243A527D46C09CF6CA58DB68"
            validation="SHA1"
            decryption="AES" />
           
 Powershall command
 PS C:\> . .\Generate-MachineKey.ps1
 PS C:\> Generate-MachineKey -validationAlgorithm SHA1
 ---------------------------------------------------------------------------------------------------------------------
