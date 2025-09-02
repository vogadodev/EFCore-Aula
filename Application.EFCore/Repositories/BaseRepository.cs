﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.EFCore.Repositories
{
    public class BaseRepository<T>: DbContext where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public DbContext DbContext => _dbContext;
        public DbSet<T> DbSet => _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<bool> ValidarExistencia(Expression<Func<T, bool>> expressao) => await _dbSet.AnyAsync(expressao);

        public async Task<T?> SelecionarObjetoAsync(Expression<Func<T, bool>> expressao) => await _dbSet.FirstOrDefaultAsync(expressao);

        public async Task<IList<T>> SelecionarListaObjetoAsync(Expression<Func<T, bool>> expressao) => await _dbSet.Where(expressao).ToListAsync();

        public async Task<IList<T>> SelecionarTodos() => await _dbSet.AsQueryable().ToListAsync();
    }
}
