using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Busniess.Models;
using Moq;
using Busniess.Services;

namespace UppgiftSeeSharp.Tests.Services;

public class UserService_Tests
{
    private readonly IFileService _fileService = fileService;
    private List<UserEntity> _users = [];

    public void Create_ShouldCreateUser()
    {
        // arrange

        // act

        // assert
    }

    public void GetAll_ShouldReturnAllUsers()
    {
        // arrange

        // act

        // assert
    }

    public void ClearList_ShouldEmptyListOfUsers()
    {
        // arrange

        // act

        // assert
    }

}
