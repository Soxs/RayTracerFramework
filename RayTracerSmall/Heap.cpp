#include "Heap.h"
#include <iostream>


Heap::Heap(const char * name)
{
	m_name = (char *)name;
	totalsize = 0;
}


Heap::~Heap()
{

}

const char * Heap::GetName() const {
	return m_name;
}

void Heap::AddAllocation(size_t size) {
	totalsize += size;
}

void Heap::RemoveAllocation(size_t size) {
	totalsize -= size;
}

size_t Heap::GetSize() {
	return totalsize;
}
