import { get } from 'http';
import React from 'react'

async function getData(){
    const response = await fetch("http://localhost:6001/search");

    if(!response.ok) throw new Error("Failed to fetch data!");

    return response.json;
}

export default async function Listings() {

    const data = await getData();
  return (
    <div>
        {JSON.stringify(data)}
    </div>
  )
}
