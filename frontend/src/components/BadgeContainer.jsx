import React from 'react'
import Badge from './shared/Badge'

export default function BadgeContainer() {
  const badgeConfig = { 
    // Colors
    white: { 
      bgColor: 'bg-neutral-100',
      textColor: 'text-neutral-800',
      darkBgColor: 'dark:bg-neutral-200',darkTextColor: 'dark:text-neutral-900',
      stripColor: 'bg-gray-900',
      text: 'fundamental'
    },
    blue: { 
      bgColor: 'bg-blue-100',
      textColor: 'text-blue-800',
      darkBgColor: 'dark:bg-blue-200',darkTextColor: 'dark:text-blue-900',
      stripColor: 'bg-gray-900',
      text: 'intermediate'
    },
    purple: { 
      bgColor: 'bg-purple-100',
      textColor: 'text-purple-800',
      darkBgColor: 'dark:bg-purple-200',darkTextColor: 'dark:text-purple-900',
      stripColor: 'bg-gray-900',
      text: 'intermediate'
    }, 
    brown: { 
      bgColor: 'bg-amber-900',
      textColor: 'text-amber-400',
      darkBgColor: 'dark:bg-amber-200',darkTextColor: 'dark:text-amber-900',
      stripColor: 'bg-gray-900',
      text: 'advance'
    },
    black:{ 
      bgColor: 'bg-gray-900',
      textColor: 'text-gray-100',
      darkBgColor: 'dark:bg-gray-200',darkTextColor: 'dark:text-gray-900',
      stripColor: 'bg-red-500',
      text: 'advance2'
    }
  }
  return (
    <div className="mt-8">
    {Object.keys(badgeConfig).map(function(key, index) { 
      return <Badge key={key} color={badgeConfig[key]}/>
    })}
  </div>
  )
}
