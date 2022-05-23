import React from 'react'

export default function Badge({color}) {
  const {bgColor, textColor, darkBgColor,darkTextColor, stripColor, text} = color

  return (
    <span className={`
      cursor-pointer
      mx-2 
      font-semibold
      px-5
      py-0.5
      rounded
      ${bgColor} 
      ${textColor}  
      ${darkBgColor} 
      ${darkTextColor}
    `}>
      {text}
      <span className={`
        ml-6
       mr-0
        px-8
       py-0.5
        ${stripColor}`}>
      </span>
    </span>
  )
}
