export default function RootLayout({
    children,
},{
    children:React.ReactNode
}){
    return(
        <html lang="en">
            <body>
                {/* layout ui */}
                <main>{children}   fff</main>
            </body>
        </html>
    )
}