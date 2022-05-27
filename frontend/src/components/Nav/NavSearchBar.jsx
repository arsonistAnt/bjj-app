import React from 'react'

export default function NavSearchBar() {
  return (
    <div className='flex mr-auto items-center'>
      <input type="text" placeholder='Search moves' />
      <div>
        <button className='bg-indigo-600 text-white text-sm leading-6 font-medium py-2 px-3 rounded-lg' type='button'>Search</button>
      </div>
  </div>
  )
}
