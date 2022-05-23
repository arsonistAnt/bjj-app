import React from 'react'
import Nav from './Nav/Nav'

export default function Home() {
  return (
    <div>
      <Nav/>
      <main className='w-full h-screen flex justify-center bg-slate-100'>
        <div className="w-7/12 flex justify-center bg-slate-300 border-x-2 border-x-slate-700">
          Main
        </div>
      </main>
    </div>
  )
}
