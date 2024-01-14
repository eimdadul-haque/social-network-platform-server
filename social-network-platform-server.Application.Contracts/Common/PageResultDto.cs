using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Common
{
    public class PageResultDto<TEntity> where TEntity : class
    {
        public List<TEntity>? items;
        public int totalCount;

        public PageResultDto(List<TEntity>? items, int totalCount) 
        { 
            this.items = items;
            this.totalCount = totalCount;
        }
    }
}
