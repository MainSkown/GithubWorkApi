using GithubApi.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GithubApi.Repo
{
    public class ListRepo : IListRepo
    {
        private readonly IListService _listService;
        private readonly IGithubRepo _repository;
        public ListRepo(IListService listService, IGithubRepo repo)
        {
            _listService = listService;
            _repository = repo;
        }

        public async Task<User> CreateUser(string name)
        {
            var user = await _repository.CreateUser(name);

            if(user == null)
            {
                throw new NotFoundException();
            }

            await _listService.AddUser(user);

            return user;
        }

        public async Task DeleteUser(int id)
        {
            bool succeed = await _listService.DeleteUserFromList(id);

            if (succeed == false)
            {
                throw new NotFoundException();
            }
        }

        public async Task UpdateUserList(long id, string name)
        {
            var user = await _repository.CreateUser(name);
            var tempUser = await _listService.UpdateUser(id, user);
            
            if(tempUser == null)
            {
                throw new NotFoundException();
            }
        }
    }
}
