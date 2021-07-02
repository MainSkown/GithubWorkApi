using GithubApi.Data;
using GithubApi.Repo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApi.Service
{
    public class ListService : IListService
    { 
        private readonly IListRepo _listRepo;
        private readonly IGithubRepo _repository;
        public ListService(IListRepo listService, IGithubRepo repo)
        {
            _listRepo = listService;
            _repository = repo;
        }

        public async Task<User> CreateUser(string name)
        {
            var user = await _repository.CreateUser(name);

            if(user == null)
            {
                throw new NotFoundException();
            }

            await _listRepo.AddUser(user);

            return user;
        }

        public async Task DeleteUser(int id)
        {
            bool succeed = await _listRepo.DeleteUserFromList(id);

            if (succeed == false)
            {
                throw new NotFoundException();
            }
        }

        public async Task<IEnumerable<User>> ReturnAllUsers()
        {
            var users = await _listRepo.ReturnAllUsers();
                      

            return users;
        }

        public async Task<User> ReturnUserByID(long id)
        {
            var user = await _listRepo.ReturnUserByID(id);

            if(user == null)
            {
                throw new NotFoundException();
            }

            return user;
        }

        public async Task UpdateUserList(long id, string name)
        {
            var user = await _repository.CreateUser(name);
            var tempUser = await _listRepo.UpdateUser(id, user);
            
            if(tempUser == null)
            {
                throw new NotFoundException();
            }
        }
    }
}
