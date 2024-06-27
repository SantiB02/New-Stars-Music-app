import { Checkbox, Typography } from '@material-tailwind/react'
import React from 'react'

export const Settings = () => {
  return (
    <>
    <div>
        <Typography variant='h4'> Do you want to keep the "Dark Mode" turned on?</Typography>
        <div>
        <Checkbox />
        <Typography variant='h5'> Always / Nope</Typography>
        </div>
    </div>
    </>
  )
}
