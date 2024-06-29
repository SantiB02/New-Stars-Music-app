import React from 'react'

const MessagePlayer = ({theme}) => {
  
  return (
    <div className="grid h-screen place-content-center  px-4">
  <h1 className={theme?"uppercase tracking-widest text-white":"uppercase tracking-widest text-black"}>To view the available options, please enter a song title or artist.</h1>
</div>
  )
}

export default MessagePlayer