﻿using hris.Database;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hris.Seed.Application.Service
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByNameWithPositionsAsync(string departmentName)
        {
            var department = await _context.Departments
                .Include(d => d.Positions)
                .FirstOrDefaultAsync(d => d.Name == departmentName);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with name '{departmentName}' was not found.");
            }

            return department;
        }

        public async Task<Department> GetByIdWithPositionsAsync(int departmentId)
        {
            var department = await _context.Departments
                .Include(d => d.Positions)
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID '{departmentId}' was not found.");
            }

            return department;
        }

        public async Task<List<Department>> GetAllWithPositionsAsync()
        {
            return await _context.Departments
                .Include(d => d.Positions)
                .ToListAsync();
        }
    }
}
