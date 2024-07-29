 
import Layout from '../../components/layout'
import NestedLayout from '../../components/nested-layout'
 
export default function Page() {
  return (
     <b>my page</b>
  )
}
 
Page.getLayout = function getLayout(page) {
  return (
    <Layout>
      <NestedLayout>{page}</NestedLayout>
    </Layout>
  )
}