import React from 'react'
import Nav from './Nav/Nav'
import BadgeContainer from './BadgeContainer'
import '../index.css'

export default function Home() {
  return (
    <div>
      <Nav/>
      <main className='w-full h-screen flex justify-center bg-slate-100'>
        <div className="w-10/12 flex  bg-slate-300 border-x-1 border-x-slate-200">
          <BadgeContainer/>
        </div>
      </main>
    </div>
  )
}
