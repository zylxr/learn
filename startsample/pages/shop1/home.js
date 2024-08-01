import Link from 'next/link'

function Home(){
    return (
        <ul>
            <li>
                <Link href="/" >Home</Link>
            </li>
            <li>
                <Link href="/about">About us</Link>
            </li>
            <li>
                <Link href="/shop/">Shops</Link>
            </li>
        </ul>
    )
}
export default Home;