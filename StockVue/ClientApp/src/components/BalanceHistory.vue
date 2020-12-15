<template>
    <div class="container">
        <LineChart v-if="loaded"
                    :chart-data="data"
                    :chart-labels="labels"
                    :options="options" />
    </div>
</template>

<script>
    import LineChart from '@/components/LineChart.vue'
    import axios from 'axios';

    export default {
        name: 'BalanceHistory',
        components: { LineChart },
        props: {},
        data() {
            return {
                loaded: false,                
                options: null,
                data: [],
                labels: []
            }
        },
        async mounted() {
            this.loaded = false
            try {                

                axios.get('http://localhost:7071/api/portfolio/XXXXXXXXX/balancehistory').then(resp => {

                    this.data = resp.data.balanceData.map(x => x.balance);
                    this.labels = resp.data.balanceData.map(x => x.balanceDate);

                    this.loaded = true
                });

            } catch (e) {
                console.error(e)
            }
        }
    }
</script>