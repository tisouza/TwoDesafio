using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Two.Desafio.Authors;
using Two.Desafio.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace Two.Desafio.Authors
{
    [Authorize(DesafioPermissions.Authors.Default)]
    public class AuthorAppService : DesafioAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IDistributedCache<List<AuthorCacheItem>> _cache;

        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            IDistributedCache<List<AuthorCacheItem>> cache)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _cache = cache;
        }

        //...SERVICE METHODS WILL COME HERE...

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var result = await _cache.GetOrAddAsync(AuthorConsts.KeyCacheAuthor,
                async () => {
                    var authors = await _authorRepository.GetListAsync(
                                input.SkipCount,
                                input.MaxResultCount,
                                input.Sorting,
                                input.Filter
                                );
                    return ObjectMapper.Map<List<Author>, List<AuthorCacheItem>>(authors);
                    
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
                );
            //var authors = await _authorRepository.GetListAsync(
            //    input.SkipCount,
            //    input.MaxResultCount,
            //    input.Sorting,
            //    input.Filter
            //);

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<AuthorCacheItem>, List<AuthorDto>>(result)
            );
        }

        [Authorize(DesafioPermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio
            );

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize(DesafioPermissions.Authors.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }

        [Authorize(DesafioPermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }


    }
}
