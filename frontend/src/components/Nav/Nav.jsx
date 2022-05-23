import React from 'react'
import NavSearchBar from './NavSearchBar'

export default function Nav() {
  return (
    <nav className='w-full flex justify-center  py-8 bg-cyan-50'>
      <div className='w-7/12 flex justify-center bg-teal-200'>
        <div className='flex justify-center items-center mr-auto px-12 bg-yellow-300 '>
          <img src="" alt="Logo" srcset="" />
          <div>Title</div>
        </div>
        <NavSearchBar/>
      </div>
    </nav>
  )
}
