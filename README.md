# ProofPoint Essentials Client for C#
This is a C# wrapper for ProofPoint Essentials API v1

Please note this is an incomplete project at the moment and it is currently under development.

It only has wrapper Users service.

The configuration includes following steps-
1. Add 3 keys in your config file-

    a. ProofPointEssentials:Username (This is user name / email of your account)
  
    b. ProofPointEssentials:Password (This is password of your account)
  
    c. ProofPointEssentials:Base (This is Base URL. e.g. https://us3.proofpointessentials.com/api/v1/)
    
2. Example call to retrieve a list of all users

        ProofPointUserService ppUserService = new ProofPointUserService();
        var user = ppUserService.GetAllUsers(domain);
