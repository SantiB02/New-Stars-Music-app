import {useState, useEffect} from 'react'
import api from '../../api/api'
import { useAuth0 } from '@auth0/auth0-react'
export const Profile = () => {
    const {user} = useAuth0();
  return (
    <>
    <div>Profile
    <>
      <div>Profile</div>
      <h3>Email</h3>
      <p>{user.email}</p>
      <h3>Nickname</h3>
      <p>{user.nickname}</p>
      <h3>Name</h3>
      <p>{user.name}</p>
      <h3>Given Name</h3>
      <p>{user.given_name}</p>
      <h3>Family Name</h3>
      <p>{user.family_name}</p>
      <h3>Middle Name</h3>
      <p>{user.middle_name}</p>
      <h3>Preferred Username</h3>
      <p>{user.preferred_username}</p>
      <h3>Profile</h3>
      <p>{user.profile}</p>
      <h3>Picture</h3>
      <img src={user.picture} alt="Profile" />
      <h3>Website</h3>
      <p>{user.website}</p>
      <h3>Email Verified</h3>
      <p>{user.email_verified ? 'Yes' : 'No'}</p>
      <h3>Gender</h3>
      <p>{user.gender}</p>
      <h3>Birthdate</h3>
      <p>{user.birthdate}</p>
      <h3>Zone Info</h3>
      <p>{user.zoneinfo}</p>
      <h3>Locale</h3>
      <p>{user.locale}</p>
      <h3>Phone Number</h3>
      <p>{user.phone_number}</p>
      <h3>Phone Number Verified</h3>
      <p>{user.phone_number_verified ? 'Yes' : 'No'}</p>
      <h3>Address</h3>
      <p>{user.address}</p>
    </>
    </div>
    </>
  )
}
