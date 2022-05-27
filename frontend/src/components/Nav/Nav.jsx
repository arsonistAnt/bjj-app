import React from 'react'
import NavSearchBar from './NavSearchBar'

export default function Nav({title}) {
  return (
    <nav className='w-full flex justify-center py-8'>
      <div className='w-7/12 flex justify-center'>
        <div className='flex justify-center items-center mr-auto px-12'>
          <img src="" alt="" srcset="" />
          <div>{title}</div>
        </div>
        <NavSearchBar/>
      </div>
    </nav>
  )
}
