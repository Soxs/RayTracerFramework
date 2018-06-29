#pragma once
#include <cassert>

class MemoryPool
{
public:
	MemoryPool() : ptr(mem)
	{
	}

	void* allocate(int mem_size)
	{
		assert((ptr + mem_size) <= (mem + sizeof mem) && "POOL FULL");
		void* mem = ptr;
		ptr += mem_size;
		return mem;
	}

	MemoryPool(const MemoryPool&);
	MemoryPool& operator=(const MemoryPool&);

private:
	
	char mem[4096];
	char* ptr;
};
